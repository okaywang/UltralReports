 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Filters
{
    public class LoggingFilterAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var bll = new LogOperationBussinessLogic();
            //var model = new LogOperation()
            //{
            //    UserName = UserContext.Current.Name,
            //    RequestInfo = HttpContext.Current.Request.Url.ToString(),
            //    Message = filterContext.ActionDescriptor.ActionName
            //};
            //bll.Insert(model);
             
            base.OnActionExecuting(filterContext);
        }
    }
}