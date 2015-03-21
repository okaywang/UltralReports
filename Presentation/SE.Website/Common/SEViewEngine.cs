using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Common
{
    public class SEViewEngine : RazorViewEngine
    {
        private static string[] NewPartialViewFormats = new[] { "~/Views/Shared/Modules/{0}.cshtml" };

        public SEViewEngine()
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NewPartialViewFormats).ToArray();
        }
    }
}