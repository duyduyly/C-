using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Admin.Data
{
    public class PaginationDTO
    {
        public int PageNumber {  get; set; }
        public int TotalPage { get; set; }
        public int TotalPerItem {  get; set; }
        public int TotalItemPage {  get; set; } 

    }
}