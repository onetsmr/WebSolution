using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebSolution.Data;
using WebSolution.Models;
using WebSolution.Web.Controllers.API.Base;

namespace WebSolution.Web.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/users")]
    public class UserApiController : BaseApiController
    {
        [Route(""), HttpGet]
        public IEnumerable<UserListViewModel> GetUsers()
        {
            return DataBase.Users
                .Select(e => UserListViewModel.MapFrom(e))
                .Select(e =>
                {
                    if (CurrentUser.RoleType == RoleTypeOption.Admin && e.Id.ToString() != CurrentUser.Id)
                    {
                        e.EnableLogOutAction = true;
                    }

                    return e;
                });
        }

        [Route("logout/{id}"), HttpGet]
        public void Logout(int id)
        {
            UserManager.UpdateSecurityStampAsync(id.ToString());
        }
    }
}
