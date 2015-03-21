using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public interface IValueTextEntry
    {
        int Value { get; set; }
        string Text { get; set; }
    }
}
