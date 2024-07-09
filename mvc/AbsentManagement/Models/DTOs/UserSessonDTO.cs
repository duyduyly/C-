using AbsentManagement.Areas.Home.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Models.DTOs
{
    public class UserSessonDTO 
    { 

        public UserSessonDTO(){
            this.userId = 0;
            this.Username = string.Empty;
            this.userRole = RoleEnum.USER;
        }
        public string Username { get; set; }
        public long userId { get; set; }
        public int userRole { get; set; }
    }
}