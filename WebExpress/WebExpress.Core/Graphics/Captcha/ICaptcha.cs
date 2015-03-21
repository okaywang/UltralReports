using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core 
{
    public interface ICaptcha
    {
        string Captcha { get; }
        string Result { get; }
    }
}
