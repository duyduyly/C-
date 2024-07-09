using AbsentManagement.Areas.Home.Data.Enums;
using AbsentManagement.Models.DTOs;
using AbsentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbsentManagement.Services
{
    public class LoginService : ILoginService
    {
       
        DbConnection dbConnection;
        public LoginService(DbConnection dbConnection)
        {
            this.dbConnection=dbConnection;
        }

        public string check(LoginDTO loginDTO, UserSessonDTO userSesson)
        {
            if (loginDTO==null) return null;
            var account = dbConnection.Accounts.Where(x => x.username.Equals(loginDTO.Username)&&x.password.Equals(loginDTO.Password)).FirstOrDefault();
            if (account==null) return null;
            if (loginDTO.Username.Equals(account.username)&&loginDTO.Password.Equals(account.password))
            {
                userSesson.Username = account.username;
                userSesson.userId = account.id;
                userSesson.userRole=account.account_role;
                return this.redirect(account);
            };

            return null;
        }

        public string redirect(Account account)
        {
            if (account==null) return "~/";
            if (account.account_role==RoleEnum.USER)
            {
                return "~/Home/Home/Index";
            }
            else
            {
                return "~/Admin/Home/Index";
            }
        }

        public static UserSessonDTO getUser()
        {
           var userSessonDTO = HttpContext.Current.Session[Constant.USER_SESSON];
           return userSessonDTO != null? (UserSessonDTO) userSessonDTO : new UserSessonDTO();
        }
    }
}