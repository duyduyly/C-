using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Admin.Data.Request
{
    public class FilterRequest
    {
        public string StudentName {  get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public string SortField { get; set; }
        public string SortType { get; set; }
    }
}