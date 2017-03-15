using System.Web.Http;
using AutoMapper;
using Ninject;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Api.Interfaces;
using rassler.backend.infrastructure.Api.Services;
using rassler.backend.infrastructure.Api.Utilities;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Services;
using rassler.backend.infrastructure.Database.Services.Base;
using rassler.backend.infrastructure.Database.Services.Repositories;
using rassler.backend.infrastructure.Database.UnitOfWork;

namespace rassler.backend.infrastructure.Api
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            config.DependencyResolver = CreateDependencyResolver();
        }

        private static System.Web.Http.Dependencies.IDependencyResolver CreateDependencyResolver()
        {
            var kernel = new StandardKernel();
            kernel.Bind<HttpStatusCodeMapping>().To<HttpStatusCodeMapping>().InSingletonScope();
            kernel.Bind<IHttpStatusCodeParser>().To<HttpStatusCodeParser>();

            kernel.Bind<RepositoryFactory>().To<RepositoryFactory>().InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            var mapper = CreateDataMapper();
            kernel.Bind<IMapper>().ToConstant(mapper).InSingletonScope();

            return new NinjectResolver(kernel);
        }

        private static IMapper CreateDataMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<domain.DTO.User, User>();
                cfg.CreateMap<domain.DTO.Profile, domain.Model.Profile>();
                cfg.CreateMap<domain.DTO.Class, Class>();
                cfg.CreateMap<domain.DTO.Rank, Rank>();
                cfg.CreateMap<domain.DTO.School, School>();
                cfg.CreateMap<domain.DTO.AttendanceRecord, AttendanceRecord>();
                cfg.CreateMap<domain.DTO.CanceledClass, CanceledClass>();
                cfg.CreateMap<domain.DTO.Payment, Payment>();
                cfg.CreateMap<domain.DTO.ContactInfo, ContactInfo>();
            });
            return config.CreateMapper();
        }
    }
}