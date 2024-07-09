using AbsentManagement.Areas.Admin.Data;
using AbsentManagement.Areas.Home.Data.Enums;
using AbsentManagement.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbsentManagement.App_Start
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        private RoleDTO[] roles = new RoleDTO[]
       {
            (new RoleDTO(id: 1,name: "Display admin",userrole: RoleEnum.ADMIN)),
            (new RoleDTO(id: 2,name: "Approve Absent",userrole: RoleEnum.ADMIN)),
            (new RoleDTO(id: 3,name: "Display Home Index",userrole: RoleEnum.USER)),
            (new RoleDTO(id: 4,name: "Display Information Index",userrole: RoleEnum.USER))
       };
        public int Id { get; set;}
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //check sesson
            // if sesson is Null return Login action
            UserSessonDTO userSesson = (UserSessonDTO) HttpContext.Current.Session[Constant.USER_SESSON];
            if (userSesson!=null)
            {
                foreach (var item in this.roles)
                {
                    if (item.Id == this.Id && userSesson.userRole == item.UserRole)
                    {
                        return;
                    }
                   
                }
                redirect(controller: "Error", action: "PermissionNotFound", area: "", filterContext: filterContext);
                return;
            }
            redirect(controller: "Login", action: "Index", area: "", filterContext: filterContext);
        }

        private void redirect(string controller, string action, string area, AuthorizationContext filterContext)
        {
            var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
            filterContext.Result=new RedirectToRouteResult(new
                System.Web.Routing.RouteValueDictionary(
                    new
                    {
                        controller = controller,
                        action = action,
                        area = area
                    }

                ));
        }

    }
}