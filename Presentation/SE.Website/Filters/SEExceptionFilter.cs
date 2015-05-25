using WebExpress.Website;
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
            if (ex.InnerException != null)
            {
                return ex.Message + "\n\rInnerException\n\r" + GetExceptionMessage(ex.InnerException);
            }
            return ex.Message;
        }
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var msg = string.Format("发生错误，请于管理员联系。<br />错误信息： {0}", GetExceptionMessage(filterContext.Exception));
                var result = new ResultModel(false, msg);
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

            LogException(filterContext.Exception);
        }

        private void LogException(Exception ex)
        {
            try
            {
                using (var entities = new UltralReportsEntities())
                {
                    var bll = new LogExceptionBussinessLogic(new EfRepository<LogException>(entities));

                    var exMsg = GetExceptionMessage(ex);
                    var model = new LogException()
                    {
                        UserName = UserContext.Current.Name,
                        StackTrace = ex.StackTrace,
                        Message = exMsg,
                        RequestInfo = HttpContext.Current.Request.ToRaw()
                    };
                    bll.Insert(model);
                }
            }
            catch (Exception)
            {
                //
            }

        }
    }
}