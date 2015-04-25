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
            query = query.Where(i => i.Flag == true);
            query = query.Where(i => i.IsProRecord == criteria.SearchProRecord); 
            if (criteria.PartId.HasValue)
            {
                query = query.Where(i => i.PartId >= criteria.PartId.Value);
            }
            if (criteria.Duty.HasValue)
            {
                query = query.Where(i => i.Duty >= criteria.Duty);
            }
            if (criteria.MajorId.HasValue)
            {
                query = query.Where(i => i.Part.MajorId >= criteria.MajorId.Value);
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
            if (criteria.Duty.HasValue)
            {
                query = query.Where(i => i.Duty == criteria.Duty.Value);
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
        public PagedList<UltraSummary> SearchSummaryByNativeSql(UltraSummarySearchCriteria criteria)
        {
            throw new NotImplementedException();
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
            query = query.Where(i => i.Flag == true);
            query = query.Where(i=>i.IsProRecord == criteria.SearchProRecord);
            if (criteria.BeginTime.HasValue)
            {
                query = query.Where(i => i.StartTime >= criteria.BeginTime.Value);
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
                             L3 = gr.Max(i => i.Part.L3),
                             H1 = gr.Max(i => i.Part.H1),
                             Times = gr.Count(),
                             Duration = gr.Sum(i => EntityFunctions.DiffMinutes(i.StartTime, i.EndTime).Value),
                             MajorName = gr.Max(i => i.Part.Major.Name),
                             Remarks = gr.Max(i => i.Remarks)
                         };

            query2 = query2.OrderBy<UltraSummary>(criteria.OrderByFields);
            var result = new PagedList<UltraSummary>(query2, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }
    }


}
