using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rassler.backend.domain.Model.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;
using rassler.backend.infrastructure.Database.Services.Base;
using rassler.backend.infrastructure.Database.Services.Repositories;

namespace rassler.backend.infrastructure.Database.Services
{
    public class RepositoryFactory
    {
        public RepositoryFactory()
        {
            _repositoryFactories = GetFactories();
        }

        public RepositoryFactory(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForType<T>() where T : class, IEntity
        {
            return GetRepositoryFactory<T>() ?? GetDefaultRepositoryFactory<T>();
        }

        public Func<DbContext, object> GetDefaultRepositoryFactory<T>() where T : class, IEntity
        {
            return dbContext => new Repository<T>(dbContext);
        }

        private IDictionary<Type, Func<DbContext, object>> GetFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
                {
                   {typeof(IAttendanceRecordsRepository), dbContext => new AttendanceRecordsRepository(dbContext)},
                   {typeof(ICanceledClassesRepository), dbContext => new CanceledClassesRepository(dbContext)},
                   {typeof(IClassesRepository), dbContext => new ClassesRepository(dbContext)},
                   {typeof(IContactInfosRepository), dbContext => new ContactInfosRepository(dbContext)},
                   {typeof(IPaymentsRepository), dbContext => new PaymentsRepository(dbContext)},
                   {typeof(IProfilesRepository), dbContext => new ProfilesRepository(dbContext)},
                   {typeof(IRanksRepository), dbContext => new RanksRepository(dbContext)},
                   {typeof(ISchoolsRepository), dbContext => new SchoolsRepository(dbContext)},
                   {typeof(IStandingsRepository), dbContext => new StandingsRepository(dbContext)},
                   {typeof(IUsersRepository), dbContext => new UsersRepository(dbContext)},
                };
        }

        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;
    }
}
