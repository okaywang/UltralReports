using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Common;

namespace Website.Filters
{
    public class RequireAuthorityAttribute : AuthorizeAttribute
    {
        private string _authorityName;
        public RequireAuthorityAttribute(string authorityName)
        {
            _authorityName = authorityName;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var hasAuthority = UserContext.Current.HasAuthority(_authorityName);
            if (!hasAuthority)
            {
                throw new HttpException((int)HttpStatusCode.Unauthorized, "Unauthorized");
            } 
            return hasAuthority;
        }
    }
}