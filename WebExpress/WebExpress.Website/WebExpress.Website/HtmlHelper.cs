using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebExpress.Core;

namespace WebExpress.Website
{
    public static class MyHtmlHelper
    {
        public static string Option(this HtmlHelper helper, Enum item)
        {
            return string.Format("<option value={0}>{1}</option>", Convert.ToInt32(item), item.GetDisplayText());
        }

        public static string Option(this HtmlHelper helper, NameValuePair item)
        {
            return string.Format("<option value={0}>{1}</option>", item.Value, item.Name);
        }
    }
}
