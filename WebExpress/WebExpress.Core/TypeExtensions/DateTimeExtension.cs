using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public static class DateTimeExtension
    {
        public static DateTime EndOfDay(this DateTime dt)
        {
            return DateTime.Parse(dt.ToShortDateString().Trim() + " 23:59:59");
        }

        public static DateTime BeginOfDay(this DateTime dt)
        {
            var x = dt.ToString("yyyy-MM-dd");
            return DateTime.Parse(x + " 00:00:00");
        }

        public static string ToGeneralString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToShortGeneralString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }
        public static string ToShortGeneralString(this DateTime? dt)
        {
            if (dt.HasValue)
            {
                return dt.Value.ToShortGeneralString();
            }
            return string.Empty;
        }

        public static bool WithinPeriod(this DateTime dt, DateTime? begin, DateTime? end)
        {
            return dt >= begin && dt <= end;
        }

        public static bool WithinPeriod(this DateTime dt, DateTime begin, DateTime end)
        {
            return dt >= begin && dt <= end;
        }

        public static bool WithinPeriod(this TimeSpan ts, TimeSpan begin, TimeSpan end)
        {
            return ts >= begin && ts <= end;
        }
    }
}
