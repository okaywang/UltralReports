using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class UltraReportBussinessLogic : BussinessLogicBase<UltraRecord>
    {
        public UltraReportBussinessLogic(EfRepository<UltraRecord> repository)
            : base(repository)
        {

        }
    }
}
