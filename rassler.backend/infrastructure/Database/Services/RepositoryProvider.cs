using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rassler.backend.domain.Model.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces;

namespace rassler.backend.infrastructure.Database.Services
{
    public class RepositoryProvider : IRepositoryProvider
    {
        public DbContext Context { get; set; }

        protected RepositoryFactory RepositoryFactory { get; set; }

        protected Dictionary<Type, object> Repositories { get; }

        public RepositoryProvider(RepositoryFactory repositoryFactory)
        {
            RepositoryFactory = repositoryFactory;
            Repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepositoryForType<T>() where T : class, IEntity
        {
            return GetRepository<IRepository<T>>(
                RepositoryFactory.GetRepositoryFactoryForType<T>());
        }

        public T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }

            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository<T>(factory, Context);
        }

        public void SetRepository<T>(T repository)
        {
            throw new NotImplementedException();
        }

        public ISecuredRepository<T> GetSecuredRepositoryForType<T>() where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public T GetSecuredRepository<T>(Func<DbContext, object> factory = null) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public void SetSecuredRepository<T>(T repository)
        {
            throw new NotImplementedException();
        }

        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? RepositoryFactory.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            }
            var repo = (T)f(dbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }
    }
}
