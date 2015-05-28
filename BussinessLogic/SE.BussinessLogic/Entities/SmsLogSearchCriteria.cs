using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace BussinessLogic
{
    public class SmsLogSearchCriteria : SearchCriteria<SmsLog>
    {
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
