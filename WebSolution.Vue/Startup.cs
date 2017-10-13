using System.Collections.Generic;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebSolution.Vue.Startup))]
namespace WebSolution.Vue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            Web.Infrastructure.Screens.ScreenTemplates.Init(new Dictionary<string, string>
            {
                { "modalDialog", "components\\modalDialog.html" },
                { "modules", "modules\\modules.html" },
                { "dashboard", "modules\\dashboard\\dashboard.html" },
                { "roles", "modules\\roles\\roles.html" },
                { "role", "modules\\roles\\role\\role.html" },
                { "users", "modules\\users\\users.html" },
            });
        }
    }
}
