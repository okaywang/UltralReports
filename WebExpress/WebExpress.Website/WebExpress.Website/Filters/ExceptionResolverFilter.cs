using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebExpress.Website.Exceptions;

namespace WebExpress.Website.Filters
{
    public class ExceptionResolverFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            ResolveException(filterContext);
        }

        private void ResolveException(ExceptionContext filterContext)
        {
            //var sourceException = filterContext.Exception;
            //if (sourceException is DataNotFoundException)
            //{
            //    filterContext.Result = new HttpNotFoundResult();
            //    filterContext.ExceptionHandled = true;
            //}
            //else if (sourceException is AuthorizationException)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //    filterContext.ExceptionHandled = true;
            //}
        }
    }
}