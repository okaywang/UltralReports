using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core.Guards
{
    public static class Guard
    {
        public static void IsNotNull<T>(object obj) where T : Exception, new()
        {
            if (obj == null)
            {
                throw new T();
            }
        }

        public static void IsNotNull<T>(object obj,string argument) where T : Exception, new()
        {
            if (obj == null)
            {
                var ex = (T)Activator.CreateInstance(typeof(T), argument);
                throw ex;
            }
        }
    }
}
