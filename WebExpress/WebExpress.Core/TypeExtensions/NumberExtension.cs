using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public static class NumberExtension
    {
        public static string ToMoneyFormat(this decimal? dec, int precision = 2)
        {
            if (dec.HasValue)
            {
                return dec.Value.ToMoneyFormat(precision);
            }
            return string.Empty;
        }

        public static string ToMoneyFormat(this int dec, int precision = 2)
        {
            return string.Format("{0:C" + precision + "}", dec, precision);
        }

        public static string ToMoneyFormat(this decimal dec, int precision = 2)
        {
            return string.Format("{0:C" + precision + "}", dec, precision);
        }
    }
}
