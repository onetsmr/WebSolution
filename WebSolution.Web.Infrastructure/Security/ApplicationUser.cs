using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WebSolution.Data;
using Microsoft.AspNet.Identity;

namespace WebSolution.Web.Infrastructure.Security
{
    public class ApplicationUser : ClaimsIdentity, IUser, ICurrentUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string DisplayName { get; set; }

        public RoleTypeOption RoleType { get; set; }

        public string RoleName { get; set; }

        public string SecurityStamp { get; set; }

        public static ApplicationUser MapFrom(User entity)
        {
            if (entity == null)
                return null;

            return new ApplicationUser
            {
                Id = entity.Id.ToString(),
                UserName = entity.UserName,
                Email = entity.Email,
                EmailConfirmed = entity.EmailConfirmed,
                DisplayName = $"{entity.FirstName} {entity.LastName}",
                RoleType = entity.Role.RoleType,
                RoleName = entity.Role.Name,
                SecurityStamp = entity.SecurityStamp
            };
        }

        public static User MapTo(ApplicationUser model)
        {
            if (model == null)
                return null;

            return MapTo(model, new User
            {
                Id = string.IsNullOrEmpty(model.Id)
                    ? 0 :
                    Convert.ToInt32(model.Id)
            });
        }

        public static User MapTo(ApplicationUser model, User entity)
        {
            if (model == null || entity == null)
                return null;

            var names = model.DisplayName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            entity.UserName = model.UserName;
            entity.Email = model.Email;
            entity.EmailConfirmed = model.EmailConfirmed;
            entity.FirstName = names.Length == 2
                ? names[0]
                : model.DisplayName;
            entity.LastName = names.Length == 2
                ? names[0]
                : string.Empty;
            entity.SecurityStamp = model.SecurityStamp;

            return entity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here


            return userIdentity;
        }
    }
}