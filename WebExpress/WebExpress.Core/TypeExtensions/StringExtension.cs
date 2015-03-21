using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public static class StringExtension
    {
        public static string ToForwardSlashPath(this string path)
        {
            return path.Replace('\\', '/');
        }
    }
}
