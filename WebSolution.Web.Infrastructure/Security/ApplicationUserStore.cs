using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSolution.Data;
using Microsoft.AspNet.Identity;

namespace WebSolution.Web.Infrastructure.Security
{
    public class ApplicationUserStore :
        IUserStore<ApplicationUser>,
        IUserPasswordStore<ApplicationUser>,
        IUserLoginStore<ApplicationUser>,
        IUserEmailStore<ApplicationUser>,
        IUserSecurityStampStore<ApplicationUser>,
        IUserLockoutStore<ApplicationUser, string>,
        IUserTwoFactorStore<ApplicationUser, string>
    {
        private readonly object _syncObject = new object();

        // Key is UserName
        private static readonly Dictionary<string, List<UserLoginInfo>> _userLoginInfos = new Dictionary<string, List<UserLoginInfo>>();

        #region IDisposable

        public void Dispose()
        {

        }

        #endregion

        #region IUserStore

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return ApplicationUser.MapFrom(FindUserById(userId));
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return ApplicationUser.MapFrom(FindUserByUserName(userName));
        }

        public async Task CreateAsync(ApplicationUser user)
        {
            var entity = ApplicationUser.MapTo(user);

            lock (_syncObject)
            {
                entity.Id = DataBase.Users.Max(e => e.Id) + 1;
            }

            entity.RoleId = DataBase.Roles.First().Id;
            entity.Role = DataBase.Roles.First();

            DataBase.Users.Add(entity);

            user.Id = entity.Id.ToString();
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            var entity = FindUser(user);

            if (entity != null)
            {
                ApplicationUser.MapTo(user, entity);
            }
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            var entity = FindUser(user);

            if (entity != null)
            {
                if (_userLoginInfos.ContainsKey(entity.UserName))
                {
                    _userLoginInfos.Remove(entity.UserName);
                }

                DataBase.Users.Remove(entity);
            }
        }

        private User FindUser(ApplicationUser user)
        {
            var entity = FindUserById(user.Id);

            if (entity == null)
            {
                entity = FindUserByUserName(user.Name);
            }

            if (entity == null)
            {
                entity = FindUserByEmail(user.Email);
            }

            return entity;
        }

        private User FindUserById(string id)
        {
            return DataBase.Users.SingleOrDefault(e => e.Id.ToString() == id);
        }

        private User FindUserByUserName(string userName)
        {
            return DataBase.Users.SingleOrDefault(e => e.UserName == userName);
        }

        private User FindUserByEmail(string email)
        {
            return DataBase.Users.SingleOrDefault(e => e.Email.ToLower() == email.ToLower());
        }

        #endregion

        #region IUserPasswordStore

        public async Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            var entity = FindUser(user);

            return string.IsNullOrEmpty(entity?.Password) == false;
        }

        public async Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            var entity = FindUser(user);

            return entity?.Password;
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            var entity = FindUser(user);

            entity.Password = passwordHash;
        }

        #endregion

        #region IUserLoginStore

        public async Task AddLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            if (_userLoginInfos.ContainsKey(user.UserName) == false)
            {
                _userLoginInfos.Add(user.UserName, new List<UserLoginInfo>());
            }

            _userLoginInfos[user.UserName].Add(login);
        }

        public async Task RemoveLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            if (_userLoginInfos.ContainsKey(user.UserName) == false)
            {
                return;
            }

            _userLoginInfos[user.UserName].Remove(login);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user)
        {
            if (_userLoginInfos.ContainsKey(user.UserName) == false)
                return null;

            return _userLoginInfos[user.UserName];
        }

        public async Task<ApplicationUser> FindAsync(UserLoginInfo login)
        {
            var keyValuePair = _userLoginInfos.AsQueryable()
                .FirstOrDefault(k => k.Value.Any(v => v.LoginProvider == login.LoginProvider &&
                                                      v.ProviderKey == login.ProviderKey));

            if (keyValuePair.Key == null)
                return null;

            return await FindByNameAsync(keyValuePair.Key);
        }

        #endregion

        #region IUserEmailStore

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return ApplicationUser.MapFrom(FindUserByEmail(email));
        }

        public async Task<string> GetEmailAsync(ApplicationUser user)
        {
            var entity = FindUser(user);

            return entity?.Email ?? user.Email;
        }

        public async Task SetEmailAsync(ApplicationUser user, string email)
        {
            user.Email = email;

            await UpdateAsync(user);
        }

        public async Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            var entity = FindUser(user);

            return entity?.EmailConfirmed ?? false;
        }

        public async Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;

            await UpdateAsync(user);
        }

        #endregion

        #region IUserSecurityStampStore

        public async Task<string> GetSecurityStampAsync(ApplicationUser user)
        {
            var entity = FindUser(user);

            return entity?.SecurityStamp;
        }

        public async Task SetSecurityStampAsync(ApplicationUser user, string stamp)
        {
            user.SecurityStamp = stamp;

            await UpdateAsync(user);
        }

        #endregion

        #region IUserLockoutStore

        public async Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public async Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task ResetAccessFailedCountAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            return false;
        }

        public async Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserTwoFactorStore

        public async Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            return false;
        }

        public async Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {

        }

        #endregion
    }
}