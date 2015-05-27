using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace BussinessLogic
{
    public class UltraReportBussinessLogic : BussinessLogicBase<UltraRecord>
    {
        public UltraReportBussinessLogic(EfRepository<UltraRecord> repository)
            : base(repository)
        {

        }

        public PagedList<UltraRecord> Search(UltraRecordSearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<UltraRecord>(i => i.Id, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }
            var query = PrimaryRepository.Table;
            //query = query.Where(i => i.Flag == true);
            query = query.Where(i => i.IsProRecord == criteria.SearchProRecord);
            if (criteria.MachineSet.HasValue)
            {
                query = query.Where(i => i.Part.Equipment.MachineSet == criteria.MachineSet.Value);
            }
            //if (criteria.PartId.HasValue)
            //{
            //    query = query.Where(i => i.PartId == criteria.PartId.Value);
            //}
            query = query.Where(i => i.PartId == criteria.PartId);
            if (criteria.Duty.HasValue)
            {
                query = query.Where(i => i.Duty == criteria.Duty.Value);
            }
            if (criteria.MajorId.HasValue)
            {
                query = query.Where(i => i.Part.MajorId == criteria.MajorId.Value);
            }

            if (criteria.StartTime.HasValue)
            {
                query = query.Where(i => i.StartTime >= criteria.StartTime.Value);
            }
            if (criteria.EndTime.HasValue)
            {
                query = query.Where(i => i.EndTime <= criteria.EndTime.Value);
            }
            if (criteria.MonitorTypeId.HasValue)
            {
                query = query.Where(i => i.Part.Equipment.MonitorTypeId == criteria.MonitorTypeId.Value);
            }

            query = query.OrderBy<UltraRecord>(criteria.OrderByFields);
            var result = new PagedList<UltraRecord>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }

        /// <summary>
        /// In order to compare with SearchSummary method, this method will be implemented using native sql.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public PagedList<UltraSummary> SearchSummaryBySql(UltraSummarySearchCriteria criteria)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@"select
            ROW_NUMBER() over(order by isnull(e.Id,2147483647),isnull(p.Id,2147483647),ur.Duty) row
            ,e.Id EquipmentId
            ,max(e.Name) EquipmentName
            ,p.Id PartId
            ,max(p.Name) PartName 
            ,ur.Duty,max(p.L1) L1
            ,max(p.H1) H1
            ,SUM(DATEDIFF(mi,ur.StartTime,ur.EndTime)) Duration
            ,COUNT(1) Times
            ,max(m.Name) MonitorTypeName
            ,max(Major.Name) UserMajorName
            ,max(a.Name) UserName
            from UltraRecord ur 
                 left join Part p on ur.PartId=p.Id
	             left join Equipment e on p.EquipmentId=e.Id
	             left join MonitorType m on e.MonitorTypeId=m.Id
                 left join Account a on p.FAUserId = a.Id
	             left join Major on a.MajorId=Major.Id");

            sb.AppendLine("where");
            sb.AppendLine().AppendFormat("ur.IsProRecord={0}", Convert.ToInt32(criteria.SearchProRecord));

            if (criteria.StartTime.HasValue)
            {
                sb.AppendLine("and ").AppendFormat("ur.StartTime>='{0}'", criteria.StartTime.Value.ToString());
            }
            if (criteria.EndTime.HasValue)
            {
                sb.AppendLine("and ").AppendFormat("ur.EndTime<='{0}'", criteria.EndTime.Value.ToString());
            }
            if (criteria.MonitorTypeId.HasValue)
            {
                sb.AppendLine("and ").AppendFormat("e.MonitorTypeId={0}", criteria.MonitorTypeId.Value);
            }
            if (criteria.EquipmentId.HasValue)
            {
                sb.AppendLine("and ").AppendFormat("e.Id={0}", criteria.EquipmentId.Value);
            }
            if (!string.IsNullOrEmpty(criteria.EquipmentNamePart))
            {
                sb.AppendLine("and ").AppendFormat("e.Name like '%{0}'%", criteria.EquipmentNamePart);
            }
            if (criteria.MachineSet.HasValue)
            {
                sb.AppendLine("and ").AppendFormat("e.MachineSet={0}", criteria.MachineSet.Value);
            }
            if (criteria.Duty.HasValue)
            {
                sb.AppendLine("and ").AppendFormat("ur.Duty={0}", criteria.Duty.Value);
            }
            if (criteria.MajorId.HasValue)
            {
                sb.AppendLine("and ").AppendFormat("a.MajorId={0}", criteria.MajorId.Value);
            }
            if (!string.IsNullOrEmpty(criteria.UserName))
            {
                sb.AppendLine("and ").AppendFormat("a.Name like '%{0}%'", criteria.UserName);
            }

            sb.AppendLine().AppendLine("group by e.Id,p.Id,ur.Duty");
            var sql = sb.ToString();
            var result = PrimaryRepository.ExecuteSqlQuery2<UltraSummary>(sql, criteria.PagingRequest);
            return result;
        }

        public PagedList<UltraSummary> SearchSummary(UltraSummarySearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<UltraSummary>(i => i.EquipmentId, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }
            var query = PrimaryRepository.Table;
            //query = query.Where(i => i.Flag == true);
            query = query.Where(i => i.IsProRecord == criteria.SearchProRecord);
            if (criteria.StartTime.HasValue)
            {
                query = query.Where(i => i.StartTime >= criteria.StartTime.Value);
            }
            if (criteria.EndTime.HasValue)
            {
                query = query.Where(i => i.EndTime <= criteria.EndTime.Value);
            }
            if (criteria.MonitorTypeId.HasValue)
            {
                query = query.Where(i => i.Part.Equipment.MonitorTypeId == criteria.MonitorTypeId.Value);
            }
            if (criteria.EquipmentId.HasValue)
            {
                query = query.Where(i => i.Part.Equipment.Id == criteria.EquipmentId.Value);
            }
            if (!string.IsNullOrEmpty(criteria.EquipmentNamePart))
            {
                query = query.Where(i => i.Part.Equipment.Name.Contains(criteria.EquipmentNamePart));
            }
            if (criteria.MachineSet.HasValue)
            {
                query = query.Where(i => i.Part.Equipment.MachineSet == criteria.MachineSet.Value);
            }
            if (criteria.Duty.HasValue)
            {
                query = query.Where(i => i.Duty == criteria.Duty.Value);
            }

            query = query.Where(i => i.PartId.HasValue);

            var query2 = from r in query
                         group r by new { r.Part.EquipmentId, PartId = r.Part.Id, r.Duty } into gr
                         //orderby gr.Key.EquipmentId
                         //orderby gr.Key.PartId
                         //orderby gr.Key.Duty
                         select new UltraSummary
                         {
                             Duty = gr.Key.Duty,
                             PartId = gr.Key.PartId,
                             PartName = gr.Max(i => i.Part.Name),
                             EquipmentId = gr.Key.EquipmentId,
                             EquipmentName = gr.Max(i => i.Part.Equipment.Name),
                             MonitorTypeName = gr.Max(i => i.Part.Equipment.MonitorType.Name),
                             L1 = gr.Max(i => i.Part.L1),
                             H1 = gr.Max(i => i.Part.H1),
                             Times = gr.Count(),
                             //Duration = gr.Sum(i => EntityFunctions.DiffMinutes(i.StartTime, ((i.EndTime < i.StartTime || i.EndTime == DateTime.MinValue) ? i.StartTime : i.EndTime)).Value),
                             Duration = gr.Sum(i => EntityFunctions.DiffMinutes(i.StartTime, ((i.EndTime < i.StartTime || String.IsNullOrEmpty(i.EndTime.ToString()) || i.EndTime == DateTime.MinValue) ? i.StartTime : i.EndTime)).Value),
                             MajorName = gr.Max(i => i.Part.Major.Name),
                             Remarks = gr.Max(i => i.Remarks)
                         };

            query2 = query2.OrderBy<UltraSummary>(criteria.OrderByFields);
            var result = new PagedList<UltraSummary>(query2, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }
    }


}
