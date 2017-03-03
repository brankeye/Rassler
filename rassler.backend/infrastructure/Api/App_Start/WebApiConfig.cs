using System.Net.Http.Formatting;
using System.Web.Http;
using AutoMapper;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Api.Interfaces;
using rassler.backend.infrastructure.Api.Services;
using rassler.backend.infrastructure.Api.Utilities;
using rassler.backend.infrastructure.Database;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Services;
using Profile = rassler.backend.domain.Data.Models.Profile;

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
            config.Formatters.Remove(config.Formatters.XmlFormatter);

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

            var mapper = CreateDataMapper();
            kernel.Bind<IMapper>().ToConstant(mapper).InSingletonScope();

            return new NinjectResolver(kernel);
        }

        private static IMapper CreateDataMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<domain.Data.Models.DTOs.User, User>();
                cfg.CreateMap<domain.Data.Models.DTOs.Profile, Profile>();
                cfg.CreateMap<domain.Data.Models.DTOs.Class, Class>();
                cfg.CreateMap<domain.Data.Models.DTOs.Rank, Rank>();
                cfg.CreateMap<domain.Data.Models.DTOs.School, School>();
                cfg.CreateMap<domain.Data.DTOs.AttendanceRecord, AttendanceRecord>();
                cfg.CreateMap<domain.Data.Models.DTOs.CanceledClass, CanceledClass>();
                cfg.CreateMap<domain.Data.Models.DTOs.Payment, Payment>();
                cfg.CreateMap<domain.Data.Models.DTOs.ContactInfo, ContactInfo>();
            });
            return config.CreateMapper();
        }
    }
}
