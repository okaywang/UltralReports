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
    public class KPIBussinessLogic : BussinessLogicBase<KPIData>
    {
        private EfRepository<KPIWeight> _kpiWeightRepository;
        public KPIBussinessLogic(EfRepository<KPIData> repository, EfRepository<KPIWeight> kpiWeightRepository)
            : base(repository)
        {
            _kpiWeightRepository = kpiWeightRepository;
        }

        public KPIDataItem[] Search(DateTime? beginDate, DateTime? endDate)
        {
            var sql = new StringBuilder();
            sql.AppendLine(@"select Duty,Pointkey,case when PointKey in('A1','A2','B1','B2','A6','B6') then SUM(value) else AVG(value) end Value
                            from kpidata
                            where 1=1");
            if (beginDate.HasValue)
            {
                sql.AppendFormat(" and [date]>='{0}' \n", beginDate.Value.ToString("yyyy-MM-dd"));
            }
            if (endDate.HasValue)
            {
                sql.AppendFormat(" and [date]<='{0}' \n", endDate.Value.ToString("yyyy-MM-dd"));
            }
            sql.AppendLine("group by pointkey,duty");

            var data = PrimaryRepository.ExecuteSqlQuery<KPIDataItem>(sql.ToString()).ToArray();
            return data;
        }

        public KPIWeightItem[] GetLastestWeight(DateTime date)
        {
            var sql = string.Format(@"with tmp as
                        (select ItemType,Max(BeginDate) BeginDate 
                        from kpiweight
                        where BeginDate <= '{0}'
                        group by ItemType
                        )

                        select b.itemtype,b.Weight
                        from tmp a join kpiweight b
                        on a.itemType=b.itemtype and a.begindate = b.begindate
                        order by a.itemtype", date.ToString("yyyy-MM-dd"));
            var data = _kpiWeightRepository.ExecuteSqlQuery<KPIWeightItem>(sql);
            return data.ToArray();
        }
    }

    public class KPIDataItem
    {
        public DutyType Duty { get; set; }

        public string PointKey { get; set; }

        public decimal Value { get; set; }
    }
}
