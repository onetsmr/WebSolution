using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSolution.Vue
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            ConfigureViewEngine();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void ConfigureViewEngine()
        {
            ViewEngines.Engines.Clear();

            var engine = new RazorViewEngine();
            engine.ViewLocationFormats = engine.ViewLocationFormats.Concat(new[] { "~/Server/Views/{1}/{0}.cshtml" }).ToArray();
            engine.PartialViewLocationFormats = engine.ViewLocationFormats.Concat(new[] { "~/Server/PartialViews/{0}.cshtml" }).ToArray();

            ViewEngines.Engines.Add(engine);
        }
    }
}