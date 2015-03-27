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
    public class SmsBussinessLogic : BussinessLogicBase<SmsRecipient>
    {
        private EfRepository<SmsRecipient> _smsRecipientRepository;
        private EfRepository<SmsGroup> _smsGroupRepository;
        public SmsBussinessLogic(EfRepository<SmsRecipient> smsRecipientRepository, EfRepository<SmsGroup> smsGroupRepository)
            : base(smsRecipientRepository)
        {
            _smsGroupRepository = smsGroupRepository;
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
