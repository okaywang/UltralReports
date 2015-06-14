using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Website.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name: "EconomicIndex",
            //    url: "Report/EconomicIndex",
            //    defaults: new { controller = "Report", action="EconomicIndex", year = DateTime.Now.Year, month = DateTime.Now.Month }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}