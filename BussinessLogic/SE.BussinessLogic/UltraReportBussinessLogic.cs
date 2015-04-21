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
    public class UltraReportBussinessLogic : BussinessLogicBase<UltraRecord>
    {
        public UltraReportBussinessLogic(EfRepository<UltraRecord> repository)
            : base(repository)
        {

        }

        public PagedList<UltraRecord> Search(UltraSummarySearchCriteria criteria)
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

            if (criteria.BeginTime.HasValue)
            {
                query = query.Where(i => i.BeginTime >= criteria.BeginTime.Value);
            }
            if (criteria.EndTime.HasValue)
            {
                query = query.Where(i => i.EndTime <= criteria.EndTime.Value);
            }
            if (criteria.MonitorTypeId.HasValue)
            {
                query = query.Where(i => i.Part.Equipment.MonitorTypeId == criteria.MonitorTypeId.Value);
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

            query = query.OrderBy<UltraRecord>(criteria.OrderByFields);
            var result = new PagedList<UltraRecord>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }

        public List<UltraSummary> SearchSummary(UltraSummarySearchCriteria criteria)
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


            if (criteria.BeginTime.HasValue)
            {
                query = query.Where(i => i.BeginTime >= criteria.BeginTime.Value);
            }
            if (criteria.EndTime.HasValue)
            {
                query = query.Where(i => i.EndTime <= criteria.EndTime.Value);
            }
            if (criteria.MonitorTypeId.HasValue)
            {
                query = query.Where(i => i.Part.Equipment.MonitorTypeId == criteria.MonitorTypeId.Value);
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

            var query2 = from r in query
                         group r by new { r.Part.EquipmentId, r.Part, r.Duty } into gr
                         select new UltraSummary
                         {
                             Duty = gr.Key.Duty,
                             PartId = gr.Key.Part.Id,
                             PartName = gr.Key.Part.Name,
                             EquipmentName = gr.Key.Part.Equipment.Name,
                             MonitorTypeName = gr.Key.Part.Equipment.MonitorType.Name,
                             L3 = gr.Key.Part.L3,
                             H1 = gr.Key.Part.H1,
                             Times = gr.Count()
                         };



            //query = query.OrderBy<UltraSummary>(criteria.OrderByFields);
            //var result = new PagedList<UltraSummary>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return query2.ToList();
        }
    }


}
