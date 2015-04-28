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
    public class SmsBussinessLogic : BussinessLogicBase<SmsGroupAccount>
    {
        private EfRepository<SmsGroup> _smsGroupRepository;
        public SmsBussinessLogic(EfRepository<SmsGroupAccount> repository,EfRepository<SmsGroup> smsGroupRepository)
            : base(repository)
        {
            _smsGroupRepository = smsGroupRepository;
        }

        public SmsGroup SmsGroupGet(int id)
        {
            return _smsGroupRepository.Get(id);
        }

        public void SmsGroupUpdate(SmsGroup entity)
        {
            _smsGroupRepository.Update(entity);
        }

        public void SmsGroupDelete(SmsGroup entity)
        {
            _smsGroupRepository.Delete(entity);
        }

        public SmsGroup Insert(SmsGroup entity)
        {
            return _smsGroupRepository.Insert(entity);
        }

        public List<SmsGroup> SmsGroupGetAll()
        {
            return _smsGroupRepository.Table.ToList();
        }

    }
}
