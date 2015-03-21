using SE.BussinessLogic;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SE.WebService
{
    public class LoggingActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var bll = new LogOperationBussinessLogic();
            var model = new LogOperation();
            model.AppName = "WebService";
            model.RequestInfo = actionContext.Request.ToString();
            bll.Insert(model);
            base.OnActionExecuting(actionContext);
        }
    }
}