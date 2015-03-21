using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.BussinessLogic
{
    public class RecipientAddressBussinessLogic : BussinessLogicBase<Recipient>
    {
        public RecipientAddressBussinessLogic(EfRepository<Recipient> recipientRepository)
            : base(recipientRepository)
        {
          
        }
    }
}
