using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using WebSolution.Web.Infrastructure.Security;

namespace WebSolution.Web.Controllers.API.Base
{
    public abstract class BaseApiController : ApiController
    {
        protected ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                    _userManager = HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

                return _userManager;
            }
        }
        private ApplicationUserManager _userManager;

        protected ApplicationUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                    _currentUser = UserManager.FindByNameAsync(User.Identity.Name).Result;

                return _currentUser;
            }
        }
        private ApplicationUser _currentUser;
    }
}