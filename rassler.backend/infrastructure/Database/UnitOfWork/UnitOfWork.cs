using System;
using System.Data.Entity;
using System.Threading.Tasks;
using rassler.backend.domain.Model.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;

namespace rassler.backend.infrastructure.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected IRepositoryProvider RepositoryProvider { get; set; }

        protected Context Context { get; set; }

        public UnitOfWork(IRepositoryProvider repositoryProvider)
        {
            CreateContext();
            RepositoryProvider = repositoryProvider;
            RepositoryProvider.Context = Context;
        }

        protected void CreateContext()
        {
            Context = new Context();

            // Do NOT enable proxied entities, else serialization fails
            Context.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            Context.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            Context.Configuration.ValidateOnSaveEnabled = false;
        }

        public IStandingsRepository Standings => GetRepository<IStandingsRepository>();

        public IAttendanceRecordsRepository AttendanceRecords => GetRepository<IAttendanceRecordsRepository>();

        public ICanceledClassesRepository CanceledClasses => GetRepository<ICanceledClassesRepository>();

        public IClassesRepository Classes => GetRepository<IClassesRepository>();

        public IContactInfosRepository ContactInfos => GetRepository<IContactInfosRepository>();

        public IPaymentsRepository Payments => GetRepository<IPaymentsRepository>();

        public IProfilesRepository Profiles => GetRepository<IProfilesRepository>();

        public IRanksRepository Ranks => GetRepository<IRanksRepository>();

        public ISchoolsRepository Schools => GetRepository<ISchoolsRepository>();

        public IUsersRepository Users => GetRepository<IUsersRepository>();

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        private IRepository<T> GetRepositoryForType<T>() where T : class, IEntity
        {
            return RepositoryProvider.GetRepositoryForType<T>();
        }
        private T GetRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }
    }
}
