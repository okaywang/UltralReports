using SE.BussinessLogic;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace SE.WebService
{
    public class SEExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, System.Threading.CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                var bll = new LogExceptionBussinessLogic();
                var model = new LogException
                {
                    AppName = "WebService",
                    Message = actionExecutedContext.Exception.Message,
                    StackTrace = actionExecutedContext.Exception.StackTrace,
                };
                bll.Insert(model);
            }, cancellationToken);
        }
    }
}