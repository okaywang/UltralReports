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
    public class EquipmentBussinessLogic : BussinessLogicBase<Equipment>
    {
        private EfRepository<Equipment> _equipmentRepository;
        private EfRepository<MonitorType> _monitorTypeRepository;
        public EquipmentBussinessLogic(EfRepository<Equipment> equipmentRepository, EfRepository<MonitorType> monitorTypeRepository)
            : base(equipmentRepository)
        {
            _monitorTypeRepository = monitorTypeRepository;
        }

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

    }
}
