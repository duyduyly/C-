using AbsentManagement.Models.DTOs;
using AbsentManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbsentManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService homeService;
        public LoginController(LoginService homeService)
        { 
            this.homeService = homeService; 
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult check(LoginDTO loginDTO)
        {
            UserSessonDTO userSesson = new UserSessonDTO();
            string url = homeService.check(loginDTO, userSesson);
            if (Session[Constant.USER_SESSON]!=null||url!=null)
            {
                Session[Constant.USER_SESSON]=userSesson;
                return Redirect(url);
            }
            ModelState.AddModelError("", "Login Fail, Please try again!");
            return View("Index", loginDTO);
        }

        public ActionResult Logout()
        {
            Session.Remove(Constant.USER_SESSON);
            Session.Remove(AbsentManagement.Areas.Home.Constant.AVATAR);
            return RedirectToAction("Index");
        }

    }
}