using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace BussinessLogic
{
    public class MajorBussinessLogic : BussinessLogicBase<Major>
    {
        public MajorBussinessLogic(EfRepository<Major> repository)
            : base(repository)
        {
        }
    }
}
