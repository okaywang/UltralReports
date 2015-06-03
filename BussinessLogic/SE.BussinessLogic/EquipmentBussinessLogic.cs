using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace BussinessLogic
{
    public class EquipmentBussinessLogic : BussinessLogicBase<Equipment>
    {
        private EfRepository<PartSms> _partSmsRepository;
        private EfRepository<MonitorType> _monitorTypeRepository;
        private EfRepository<Part> _partRepository;
        public EquipmentBussinessLogic(EfRepository<Equipment> equipmentRepository, EfRepository<MonitorType> monitorTypeRepository,
            EfRepository<Part> partRepository, EfRepository<PartSms> partSmsRepository)
            : base(equipmentRepository)
        {
            _monitorTypeRepository = monitorTypeRepository;
            _partRepository = partRepository;
            _partSmsRepository = partSmsRepository;
        }

        #region Monitor Type
        public MonitorType MonitorTypeGet(int id)
        {
            return _monitorTypeRepository.Get(id);
        }

        public void MonitorTypeUpdate(MonitorType entity)
        {
            _monitorTypeRepository.Update(entity);
        }

        public void MonitorTypeDelete(MonitorType entity)
        {
            _monitorTypeRepository.Delete(entity);
        }

        public MonitorType MonitorTypeAdd(MonitorType entity)
        {
            return _monitorTypeRepository.Insert(entity);
        }

        public List<MonitorType> MonitorTypeGetAll()
        {
            return _monitorTypeRepository.Table.ToList();
        }
        #endregion

        #region Part
        public Part PartGet(int id)
        {
            return _partRepository.Get(id);
        }

        public void PartUpdate(Part entity)
        {
            _partRepository.Update(entity);
        }

        public void PartDelete(Part entity)
        {
            _partRepository.Delete(entity);
        }

        public Part PartAdd(Part entity)
        {
            return _partRepository.Insert(entity);
        }

        public List<Part> PartGetAll()
        {
            return _partRepository.Table.ToList();
        }

        public List<Part> PartWhere(Expression<Func<Part, bool>> predicate)
        {
            return _partRepository.Table.Where(predicate).ToList();
        }

        public PagedList<Part> PartSearch(PartSearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<Part>(i => i.Id, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }
            var query = _partRepository.Table;
            if (criteria.MachineSet.HasValue)
            {
                query = query.Where(i => i.Equipment.MachineSet == criteria.MachineSet.Value);
            }
            if (!string.IsNullOrEmpty(criteria.EquipmentName))
            {
                query = query.Where(i => i.Equipment.Name.Contains(criteria.EquipmentName));
            }
            if (!string.IsNullOrEmpty(criteria.PartName))
            {
                query = query.Where(i => i.Name.Contains(criteria.PartName));
            }
            if (!string.IsNullOrEmpty(criteria.UserName))
            {
                query = query.Where(i => i.FAAccount.Name.Contains(criteria.UserName));
            }
            query = query.OrderBy<Part>(criteria.OrderByFields);
            var result = new PagedList<Part>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }

        public PartSms PartSmsGet(int partId)
        {
            return _partSmsRepository.Get(partId);
        }
        public PartSms PartSmsInsert(PartSms entity)
        {
            return _partSmsRepository.Insert(entity);
        }
        public void PartSmsUpdate(PartSms entity)
        {
            _partSmsRepository.Update(entity);
        }

        #endregion

        #region Pro Part
        public List<Part> ProPartGetAll()
        {
            return _partRepository.Table.Where(i => i.MajorId.HasValue).ToList();
        }
        #endregion
    }
}
