using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{ 
    public class SearchCriteria<TEntity>
    {
        public SearchCriteria()
        {
            OrderByFields = new List<OrderByField<TEntity>>();
        }
        public IList<OrderByField<TEntity>> OrderByFields { get; set; }
        public PagingRequest PagingRequest { get; set; }
    }
}
