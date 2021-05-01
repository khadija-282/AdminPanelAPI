
using AdminPanel.IRepository;
using AdminPanel.IService;
using AdminPanel.Repository;
using AdminPanel.Services;
using AdminPanelAPI.Model;
using AdminPanelAPI.Repository.Implementation;
using AdminPanelAPI.Repository.Interface;
using AdminPanelAPI.Service.Implementation;
using AdminPanelAPI.Service.Interface; 
using CrxApi.ExLogger;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity; 

namespace AdminPanelAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IProfileService, ProfileService>();
            container.RegisterType<IProfileRepository,ProfileRepository>();

            container.RegisterType<IEducationRepository, EducationRepository>();
            container.RegisterType<IEducationService, EducationService>();
            config.DependencyResolver = new UnityResolver(container);
            config.Services.Add(typeof(IExceptionLogger), new ExceptionManagerApi());

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
