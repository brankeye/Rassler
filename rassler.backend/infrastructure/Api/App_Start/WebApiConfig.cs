using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Api.Interfaces;
using rassler.backend.infrastructure.Api.Services;
using rassler.backend.infrastructure.Api.Utilities;
using rassler.backend.infrastructure.Database;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Services;

namespace rassler.backend.infrastructure.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.DependencyResolver = CreateDependencyResolver();
        }

        private static System.Web.Http.Dependencies.IDependencyResolver CreateDependencyResolver()
        {
            var kernel = new StandardKernel();
            kernel.Bind<HttpStatusCodeMapping>().To<HttpStatusCodeMapping>().InSingletonScope();
            kernel.Bind<IHttpStatusCodeParser>().To<HttpStatusCodeParser>();

            // unsecured repos
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind(typeof(IRepository<Standing>)).To(typeof(StandingsRepository));

            // secured repos
            kernel.Bind<ISecuredRepository<User>>().To<UsersRepository>();
            kernel.Bind<ISecuredRepository<Profile>>().To<ProfilesRepository>();
            kernel.Bind<ISecuredRepository<Class>>().To<ClassesRepository>();
            kernel.Bind<ISecuredRepository<Rank>>().To<RanksRepository>();
            kernel.Bind<ISecuredRepository<School>>().To<SchoolsRepository>();
            kernel.Bind<ISecuredRepository<AttendanceRecord>>().To<AttendanceRecordsRepository>();
            kernel.Bind<ISecuredRepository<CanceledClass>>().To<CanceledClassesRepository>();
            kernel.Bind<ISecuredRepository<Payment>>().To<PaymentsRepository>();
            kernel.Bind<ISecuredRepository<ContactInfo>>().To<ContactInfosRepository>();

            return new NinjectResolver(kernel);
        }
    }
}
