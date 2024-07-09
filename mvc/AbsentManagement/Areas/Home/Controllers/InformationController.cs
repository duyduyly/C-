using AbsentManagement.App_Start;
using AbsentManagement.Areas.Home.Data.DTOs;
using AbsentManagement.Areas.Home.Services;
using AbsentManagement.Models.DTOs;
using AbsentManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbsentManagement.Areas.Home.Controllers
{
    public class InformationController : Controller
    {

        private UserSessonDTO userSessonDTO = LoginService.getUser();
        private InformationService informationService;
        
        public InformationController(InformationService informationService)
        {
            this.informationService = informationService;
        }

        [AdminAuthorize(Id = 4)]
        public ActionResult Index()
        {
            InformationDTO informationDTO = informationService.get(userSessonDTO.userId);
            return View(informationDTO);
        }

        public ActionResult update(InformationDTO informationDTO)
        {
            bool isSuccess = informationService.update(informationDTO);
            ViewBag.isSuccess=isSuccess;
            return View("Index", informationDTO);  
        }
    }
}