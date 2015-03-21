using Website.Models;
using System.Web.Mvc;
using System.Linq;
using Website.Filters; 

namespace Website.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggingFilterAttribute());
            filters.Add(new SEExceptionFilter());
            filters.Add(new ValidateModelStateAttribute());
        }
    }

}