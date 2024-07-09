using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Admin.Data.Request
{
    public class SortedRequest
    {
        public string Field { get; set; }
        public string SortedType {  get; set; }
    }
}