using System.Web.Mvc;
using System.Web.Routing;

namespace Website.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BilinRoute",
                url: "Maintenance/{action}/{id}",
                defaults: new { controller = "Bilin", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "SE.Website.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "SE.Website.Controllers" }
            );
        }
    }
}