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
                { "modules", "modules\\modules.html" },
                { "dashboard", "modules\\dashboard\\dashboard.html" },
                { "roles", "modules\\roles\\roles.html" },
                { "users", "modules\\users\\users.html" },
            });
        }
    }
}
