using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace UR.Common.Types
{
    public enum GenderType
    {
        //None = 0,

        [DisplayText("先生")]
        Male = 1,

        [DisplayText("女士")]
        Female = 2
    }
}
