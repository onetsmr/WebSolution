using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using WebSolution.Models;
using WebSolution.Web.Controllers.API.Base;

namespace WebSolution.Web.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/application")]
    public class ApplicationApiController : BaseApiController
    {
        [Route("modules"), HttpGet]
        public IEnumerable<Module> GetModules()
        {
            var modules = new List<Module>();

            modules.Add(new Module
            {
                Id = 1,
                Name = "Dashboard",
                Url = "/"
            });

            if (CurrentUser.RoleType == Data.RoleTypeOption.Admin)
            {
                modules.Add(new Module
                {
                    Id = 2,
                    Name = "Roles",
                    Url = "/Roles"
                });
            }

            modules.Add(new Module
            {
                Id = 3,
                Name = "Users",
                Url = "/Users"
            });

            return modules;
        }

        [Route("template/{templatePath}"), HttpGet]
        public string GetTemplate(string templatePath)
        {
            var templateFilePath = $"~\\Client\\Application\\screens\\{templatePath}.html";
            var templateFileName = HttpContext.Current.Request.MapPath(templateFilePath);
            return File.ReadAllText(templateFileName);
        }
    }
}
