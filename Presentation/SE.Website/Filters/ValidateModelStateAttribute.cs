using Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Filters
{

    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var viewData = filterContext.Controller.ViewData;

            if (!viewData.ModelState.IsValid)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var result = new ResultModel(false, GetErrorMessage(viewData.ModelState));
                    filterContext.Result = new JsonResult() { Data = result };
                }
            }

            base.OnActionExecuting(filterContext);
        }

        private string GetErrorMessage(ModelStateDictionary modelState)
        {
            var msg = string.Empty;
            foreach (var item in modelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    msg = item.Errors.First().ErrorMessage;
                }
            }
            return msg;
        }
    }
}