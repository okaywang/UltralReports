using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinch.Common
{
    public class Config
    {
        //public static readonly string DbConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public static readonly string DbConnectionString = "ConnectionString";
        public static readonly string Com = ConfigurationManager.AppSettings["com"];
        //public static DateTime LastTime
        //{
        //    get { return Convert.ToDateTime(ConfigurationManager.AppSettings["lasttime"]); }
        //    set { ConfigurationManager.AppSettings.Set("lasttime", value.ToString()); }
        //}
    }
}
