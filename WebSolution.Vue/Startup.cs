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
        }
    }
}
