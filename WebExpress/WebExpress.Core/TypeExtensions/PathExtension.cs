using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace WebExpress.Core
{
    public static class PathExtension
    {
        public static string CombineWithForwardSlash(this string path1, string path2)
        {
            if (path1 == null)
            {
                path1 = string.Empty;
            }
            if (path2 == null)
            {
                path2 = string.Empty;
            }
            return System.IO.Path.Combine(path1, path2).ToForwardSlashPath();
        }
    }
}
