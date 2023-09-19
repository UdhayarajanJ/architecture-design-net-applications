using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Common
{
    public class PaginationModel
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
    }
}
