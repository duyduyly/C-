using AbsentManagement.Models;
using AbsentManagement.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsentManagement.Services
{
    internal interface ILoginService
    {
        string check(LoginDTO loginDTO, UserSessonDTO sessonDTO);
        string redirect(Account account);
    }
}
