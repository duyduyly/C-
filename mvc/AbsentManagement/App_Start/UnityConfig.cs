using AbsentManagement.Areas.Home.Data.DTO;
using AbsentManagement.Areas.Home.Services;
using AbsentManagement.Services;
using AbsentManagement.Utils;
using System.Data.Common;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AbsentManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register your services here
            container.RegisterSingleton<ILoginService, LoginService>();
            container.RegisterSingleton<DbConnection, DbConnection>();
            container.RegisterSingleton<AbsentMapper, AbsentMapper>();
            container.RegisterSingleton<HomeService, HomeService>();   
            container.RegisterType<FileUtils, FileUtils>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}