using AbsentManagement.App_Start;
using AbsentManagement.Areas.Home.Data.DTOs.AbsentLog;
using AbsentManagement.Areas.Home.Data.Enums;
using AbsentManagement.Areas.Home.Services;
using AbsentManagement.Models.DTOs;
using AbsentManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AbsentManagement.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        private HomeService homeService;
        private UserSessonDTO userSessonDTO = LoginService.getUser();

        public HomeController(HomeService homeService)
        {
            this.homeService=homeService;
        }

        [AdminAuthorize(Id = 3)]
        public ActionResult Index()
        {
            this.homeViewBag();
            return View(new AbsentLogDTO());
        }


        [AdminAuthorize(Id = 5)]
        [HttpPost]
        public ActionResult AbsentLog(AbsentLogDTO absentLogDTO)
        {
            string dateErrorMessage = homeService.validateDate(absentLogDTO.From, absentLogDTO.To);
            if (ModelState.IsValid&&dateErrorMessage.IsEmpty())
            {
                absentLogDTO.StudentId=userSessonDTO.userId;
                homeService.addAbsentLog(absentLogDTO);
                return RedirectToAction("Index");
            }
            if (!dateErrorMessage.IsEmpty()) ModelState.AddModelError("", dateErrorMessage);
            this.homeViewBag();
            return View("Index", absentLogDTO);
        }

        [AdminAuthorize(Id = 5)]
        public ActionResult update(long id)
        {
            AbsentLogDTO absentLogDTO = homeService.findById(id);
            this.homeViewBag();
            return View("Index", absentLogDTO);
        }

        [AdminAuthorize(Id = 5)]
        public ActionResult remove(long id)
        {
            homeService.remove(id);
            return RedirectToAction("Index");
        }


        private void homeViewBag()
        {
            ViewBag.AbsentLogs=homeService.findAbsentLog(userSessonDTO.userId, AbsentLogStatusEnum.PENDING);
            ViewBag.Teachers=homeService.getAllTeacher();
            if (Session[Constant.AVATAR] ==null) Session[Constant.AVATAR]=homeService.getAvatarUrl(userSessonDTO.userId);
        }
    }
}