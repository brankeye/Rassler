using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rassler.backend.domain.Model.Interfaces;

namespace rassler.backend.infrastructure.Database.Interfaces
{
    public interface IRepositoryProvider
    {
        DbContext Context { get; set; }

        IRepository<T> GetRepositoryForType<T>() where T : class, IEntity;

        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;

        void SetRepository<T>(T repository);

        ISecuredRepository<T> GetSecuredRepositoryForType<T>() where T : class, IEntity;

        T GetSecuredRepository<T>(Func<DbContext, object> factory = null) where T : class, IEntity;

        void SetSecuredRepository<T>(T repository);
    }
}
