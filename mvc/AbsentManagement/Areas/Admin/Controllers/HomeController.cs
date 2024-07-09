using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using AbsentManagement.App_Start;
using AbsentManagement.Areas.Admin.Data;
using AbsentManagement.Areas.Admin.Data.Request;
using AbsentManagement.Models;

namespace AbsentManagement.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        private AdminHomeService adminHomeService;

        public HomeController(AdminHomeService adminHomeService)
        {
            this.adminHomeService=adminHomeService;
        }

        // GET: Admin/Home
        [AdminAuthorize(Id = 1)]
        public ActionResult Index(FilterRequest filter)
        {
            adminHomeService.setFilterRequest(filter);
            List<DayOffDTO> dayoff = adminHomeService.absentList(filter);
            ViewBag.dayoffs =dayoff;
            ViewBag.Filter=filter;
            return View();
        }

        [AdminAuthorize(Id = 2)]
        public ActionResult Approve(int id) 
        {
            adminHomeService.updateApproveStatus(id);
            return RedirectToAction("Index");
        }
    }
}