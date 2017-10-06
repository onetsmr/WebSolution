using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebSolution.Web.Controllers.Base.MVC;
using WebSolution.Models;
using WebSolution.Web.Infrastructure.Security;

namespace WebSolution.Web.Controllers.MVC
{
    [Authorize]
    public class ApplicationController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.CurrentUser = CurrentUser;

            return View();
        }

        #region Standard log in

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "Username and Password is requried");
                return View(model);
            }

            var user = UserManager.Find(model.UserName, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Username not found or Password is incorrect");
                return View(model);
            }

            await SignInAsync(user, model.RememberMe);

            return RedirectToLocal(returnUrl);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToLocal(null);
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var claimsIdentity = await user.GenerateUserIdentityAsync(UserManager);

            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, claimsIdentity);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Application");
        }

        #endregion

        #region External log in

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Application", new { ReturnUrl = returnUrl }));
        }

        [Route("signin-google")]
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.Failure:
                default:
                    await CreateExternalUser(loginInfo);
                    return RedirectToLocal(returnUrl);
            }
        }

        private async Task CreateExternalUser(ExternalLoginInfo loginInfo)
        {
            var user = new ApplicationUser
            {
                UserName = loginInfo.Email,
                Email = loginInfo.Email,
                DisplayName = loginInfo.DefaultUserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await UserManager.CreateAsync(user);
            if (result.Succeeded)
            {
                result = await UserManager.AddLoginAsync(user.Id, loginInfo.Login);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return;
                }
            }

            throw new Exception("Create external login failed");
        }

        #endregion
    }
}