using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public class ValueTextEntry : IValueTextEntry
    {
        public int Value { get; set; }

        public string Text { get; set; }
    }
}
