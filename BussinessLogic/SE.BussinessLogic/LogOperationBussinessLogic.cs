using UR.Common.Types;
using UR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UR.BussinessLogic
{
    public class LogOperationBussinessLogic : BussinessLogicBase<LogOperation>
    {
        public LogOperationBussinessLogic(EfRepository<LogOperation> logReposity)
            : base(logReposity)
        {

        }
    }
}
