using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Enums;
using rassler.backend.domain.Model.Interfaces;
using rassler.backend.infrastructure.Database.Objects;

namespace rassler.backend.infrastructure.Database.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : class, IEntity
    {
        DbResult<IEnumerable<T>> GetAll();

        Task<DbResult<IEnumerable<T>>> GetAllAsync();

        DbResult<IEnumerable<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        Task<DbResult<IEnumerable<T>>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

        DbResult<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);

        Task<DbResult<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>> predicate);

        DbResult<IEnumerable<T>> GetAllIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<DbResult<IEnumerable<T>>> GetAllIncludingAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        DbResult<T> Find(Expression<Func<T, bool>> predicate);

        Task<DbResult<T>> FindAsync(Expression<Func<T, bool>> predicate);

        DbResult<T> Find(object id);

        Task<DbResult<T>> FindAsync(object id);

        DbResult<T> InsertOrUpdate(T item);

        Task<DbResult<T>> InsertOrUpdateAsync(T item);

        DbResult<T> Delete(object id);

        Task<DbResult<T>> DeleteAsync(object id);

        ResultCode Save();

        Task<ResultCode> SaveAsync();
    }
}
