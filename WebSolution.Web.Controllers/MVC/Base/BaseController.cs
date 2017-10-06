using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebSolution.Web.Infrastructure.Security;

namespace WebSolution.Web.Controllers.Base.MVC
{
    public abstract class BaseController : Controller
    {
        protected ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                    _userManager = System.Web.HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

                return _userManager;
            }
        }
        private ApplicationUserManager _userManager;

        protected ApplicationSignInManager SignInManager
        {
            get
            {
                if (_signInManager == null)
                    _signInManager = System.Web.HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                return _signInManager;
            }
        }
        private ApplicationSignInManager _signInManager;

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

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