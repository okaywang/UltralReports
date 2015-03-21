  
using Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Website.Exceptions;

namespace Website
{
    public class SEExceptionFilter : IExceptionFilter
    {
        private string GetExceptionMessage(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return ex.Message + "\n\rInnerException\n\r" + GetExceptionMessage(ex.InnerException);
            }
            return ex.Message;
        }
        public void OnException(ExceptionContext filterContext)
        {
            //var bll = new LogExceptionBussinessLogic();

            //var exMsg = GetExceptionMessage(filterContext.Exception);
            //var model = new LogException()
            //{ 
            //    UserName = UserContext.Current.Name,
            //    StackTrace = filterContext.Exception.StackTrace,
            //    Message = exMsg,
            //    RequestInfo = HttpContext.Current.Request.UserAgent.ToString()
            //};
            //bll.Insert(model);


            //if (filterContext.HttpContext.Request.IsAjaxRequest())
            //{
            //    var result = new ResultModel(false, filterContext.Exception.Message);
            //    filterContext.Result = new JsonResult() { Data = result };
            //    filterContext.ExceptionHandled = true;
            //}
            //else
            //{
            //    if (filterContext.Exception is DataNotFoundException)
            //    {
            //        filterContext.Result = new HttpNotFoundResult();
            //        filterContext.ExceptionHandled = true;
            //    }
            //}
        }
    }
}