using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Enums;
using rassler.backend.domain.Data.Interfaces;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Objects;

namespace rassler.backend.infrastructure.Database.Services.Base
{
    public abstract class SecuredRepository<TContext, TModel> : Repository<TContext, TModel>, ISecuredRepository<TModel>
        where TContext : DbContext, new()
        where TModel : class, IEntity
    {
        protected string Username { get; set; }

        public void Initialize(string username)
        {
            Username = username;
        }

        protected abstract bool CanFind(TModel item);

        protected abstract Task<bool> CanFindAsync(TModel item);

        protected abstract bool CanGet(out IQueryable<TModel> list);

        protected abstract bool CanInsert(TModel item);

        protected abstract Task<bool> CanInsertAsync(TModel item);

        protected abstract bool CanDelete(object id);

        protected abstract Task<bool> CanDeleteAsync(object id);

        public override DbResult<IEnumerable<TModel>> GetAll(Expression<Func<TModel, bool>> predicate)
        {
            IQueryable<TModel> list;
            if (CanGet(out list))
            {
                var collection = list.Where(predicate).ToList();
                return ListResult(collection, DbAction.Get);
            }
            return new DbResult<IEnumerable<TModel>>(ResultCode.Unauthorized);
        }

        public override async Task<DbResult<IEnumerable<TModel>>> GetAllAsync(Expression<Func<TModel, bool>> predicate)
        {
            IQueryable<TModel> list;
            if (CanGet(out list))
            {
                var collection = await list.Where(predicate).ToListAsync();
                return ListResult(collection, DbAction.Get);
            }
            return new DbResult<IEnumerable<TModel>>(ResultCode.Unauthorized);
        }

        public override DbResult<IEnumerable<TModel>> GetAllIncluding(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> list;
            if (CanGet(out list))
            {
                list = list.Where(predicate);
                list = includeProperties.Aggregate(list, (current, includeProperty) => current.Include(includeProperty));
                var collection = list.Where(predicate).ToList();
                return ListResult(collection, DbAction.Get);
            }
            return new DbResult<IEnumerable<TModel>>(ResultCode.Unauthorized);
        }

        public override async Task<DbResult<IEnumerable<TModel>>> GetAllIncludingAsync(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> list;
            if (CanGet(out list))
            {
                list = list.Where(predicate);
                list = includeProperties.Aggregate(list, (current, includeProperty) => current.Include(includeProperty));
                var collection = await list.Where(predicate).ToListAsync();
                return ListResult(collection, DbAction.Get);
            }
            return new DbResult<IEnumerable<TModel>>(ResultCode.Unauthorized);
        }

        public override DbResult<TModel> Find(object id)
        {
            var result = base.Find(id);
            if (CanFind(result.Content))
            {
                return result;
            }
            return new DbResult<TModel>(ResultCode.Unauthorized);
        }

        public override async Task<DbResult<TModel>> FindAsync(object id)
        {
            var result = await base.FindAsync(id);
            var success = await CanFindAsync(result.Content);
            if (success)
            {
                return result;
            }
            return new DbResult<TModel>(ResultCode.Unauthorized);
        }

        public override DbResult<TModel> Find(Expression<Func<TModel, bool>> predicate)
        {
            var result = base.Find(predicate);
            var success = CanFind(result.Content);
            if (success)
            {
                return result;
            }
            return new DbResult<TModel>(ResultCode.Unauthorized);
        }

        public override async Task<DbResult<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate)
        {
            var result = await base.FindAsync(predicate);
            var success = await CanFindAsync(result.Content);
            if (success)
            {
                return result;
            }
            return new DbResult<TModel>(ResultCode.Unauthorized);
        }

        public override DbResult<TModel> InsertOrUpdate(TModel current)
        {
            if (CanInsert(current))
            {
                return base.InsertOrUpdate(current);
            }
            return new DbResult<TModel>(ResultCode.Unauthorized);
        }

        public override async Task<DbResult<TModel>> InsertOrUpdateAsync(TModel current)
        {
            if (CanInsert(current))
            {
                return await base.InsertOrUpdateAsync(current);
            }
            return new DbResult<TModel>(ResultCode.Unauthorized);
        }

        public override DbResult<TModel> Delete(object id)
        {
            if (CanDelete(id))
            {
                return base.Delete(id);
            }
            return new DbResult<TModel>(ResultCode.Unauthorized);
        }

        public override async Task<DbResult<TModel>> DeleteAsync(object id)
        {
            if (CanDelete(id))
            {
                return await base.DeleteAsync(id);
            }
            return new DbResult<TModel>(ResultCode.Unauthorized);
        }
    }
}
