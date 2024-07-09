using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Activities;

namespace AbsentManagement.Areas.Admin.Data
{
    public class RoleDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int UserRole {  get; set; }

        public RoleDTO(long id, string name, int userrole) { 
            this.Id = id;
            this.Name = name;  
            this.UserRole = userrole;
        }
    }
}