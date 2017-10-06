using System.Collections.Generic;

namespace WebSolution.Web.Infrastructure.Screens
{
    public static class ScreenTemplates
    {
        private static Dictionary<string, string> _screens;

        public static void Init(Dictionary<string, string> screens)
        {
            _screens = screens;
        }

        public static string GetTemplatePath(string templateName)
        {
            return _screens[templateName];
        }
    }
}