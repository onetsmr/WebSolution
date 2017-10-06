using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebSolution.AngularJs.Startup))]
namespace WebSolution.AngularJs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
