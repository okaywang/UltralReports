using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core.Paging
{
    public class PagingResult
    {
        public PagingResult(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }

        public int TotalCount { get; set; }
        public int RecordCount { get; set; }

        public int TotalPages
        {
            get
            {
                var val = (float)TotalCount / PageSize;
                var count = (int)Math.Ceiling(val);
                return count;
            }
        }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
