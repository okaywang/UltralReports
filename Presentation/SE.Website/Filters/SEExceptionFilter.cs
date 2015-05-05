
using Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Website.Exceptions;
using BussinessLogic;
using DataAccess;
using Website.Common;
using System.IO;

namespace Website
{
    public class SEExceptionFilter : IExceptionFilter
    {
        private string GetExceptionMessage(Exception ex)
        {
            return ex.Message;
            if (ex.InnerException != null)
            {
                return ex.Message + "\n\rInnerException\n\r" + GetExceptionMessage(ex.InnerException);
            }
            return ex.Message;
        }
        public void OnException(ExceptionContext filterContext)
        {
            var bll = new LogExceptionBussinessLogic(new EfRepository<LogException>(new UltralReportsEntities()));

            var exMsg = GetExceptionMessage(filterContext.Exception);
            var model = new LogException()
            {
                UserName = UserContext.Current.Name,
                StackTrace = filterContext.Exception.StackTrace,
                Message = exMsg,
                RequestInfo = HttpContext.Current.Request.UserAgent.ToString()
            };

            bll.Insert(model);

            try
            {
                filterContext.HttpContext.Request.InputStream.Seek(0, SeekOrigin.Begin);
                var stream = new StreamReader(filterContext.HttpContext.Request.InputStream);
                var rr = stream.ReadToEnd();

            }
            catch (Exception ex)
            {

                throw;
            }
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var result = new ResultModel(false, filterContext.Exception.Message);
                filterContext.Result = new JsonResult() { Data = result };
                filterContext.ExceptionHandled = true;
            }
            else
            {
                if (filterContext.Exception is DataNotFoundException)
                {
                    filterContext.Result = new HttpNotFoundResult();
                    filterContext.ExceptionHandled = true;
                }
            }
        }
    }
}