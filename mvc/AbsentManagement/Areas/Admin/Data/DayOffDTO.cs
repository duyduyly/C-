using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Admin.Data
{
    public class DayOffDTO
    {
        public long Id { get; set; }
        public string StudentName { get; set; }
        public string FromTo {  get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }  

    }
}