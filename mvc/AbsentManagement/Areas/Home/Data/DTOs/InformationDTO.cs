using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Home.Data.DTOs
{
    public class InformationDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public HttpPostedFileBase Avatar { get; set; }
        public string AvatarUrl { get; set; }
    }
}