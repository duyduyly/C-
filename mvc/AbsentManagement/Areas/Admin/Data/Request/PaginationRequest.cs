using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Admin.Data.Request
{
    public class PaginationRequest
    {
        public int page_number { get; set;   }
        public int pageSize { get; set; }

    }
}