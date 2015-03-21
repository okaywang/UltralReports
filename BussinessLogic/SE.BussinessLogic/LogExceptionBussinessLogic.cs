using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class LogExceptionBussinessLogic : BussinessLogicBase<LogException>
    {
        public LogExceptionBussinessLogic(EfRepository<LogException> exceptionRepository)
            : base(exceptionRepository)
        {

        }
    }
}
