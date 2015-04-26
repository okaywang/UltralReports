using Common.Types;
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
    public class DutyBussinessLogic : BussinessLogicBase<Duty>
    {
        private EfRepository<DutyTime> _dutyTimeRepository;
        public DutyBussinessLogic(EfRepository<Duty> repository, EfRepository<DutyTime> dutyTimeRepository)
            : base(repository)
        {
            _dutyTimeRepository = dutyTimeRepository;
        }

        public List<DutyTime> DutyTimeGetAll()
        {
            return _dutyTimeRepository.Table.ToList();
        }

        public DutyTime DutyTimeGet(DutyTimeType id)
        {
            return _dutyTimeRepository.Get(id);
        }

        public void DutyTimeUpdate(DutyTime entity)
        {
            _dutyTimeRepository.Update(entity);
        }
    }
}
