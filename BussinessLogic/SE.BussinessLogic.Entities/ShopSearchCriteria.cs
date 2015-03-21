using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace SE.BussinessLogic.Entities
{
    public class ShopSearchCriteria : SearchCriteria<SE.DataAccess.Shop>
    {
        public string Name { get; set; }

        public string NamePart { get; set; }

        public int? ProviceId { get; set; }

        public int? CityId { get; set; }

        public int? CountyId { get; set; }
    }
}
