using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Enums;
using rassler.backend.domain.Model.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Objects;

namespace rassler.backend.infrastructure.Database.Services.Base
{
    public class Repository<TModel> : IRepository<TModel>
        where TModel : class, IEntity
    {
        protected DbContext Context { get; set; }

        protected DbSet<TModel> Set { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
            Set = Context.Set<TModel>();
        }

        public virtual DbResult<IEnumerable<TModel>> GetAll()
        {
            var resultCode = ResultCode.Success;
            var query = Set.ToList();
            return new DbResult<IEnumerable<TModel>>(resultCode, query);
        }

        public virtual async Task<DbResult<IEnumerable<TModel>>> GetAllAsync()
        {
            var query = await Set.ToListAsync();
            return ListResult(query, DbAction.Get);
        }

        public virtual DbResult<IEnumerable<TModel>> GetAllIncluding(params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = Set.AsQueryable();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return ListResult(query, DbAction.Get);
        }

        public virtual async Task<DbResult<IEnumerable<TModel>>> GetAllIncludingAsync(params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = Set.AsQueryable();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            IEnumerable<TModel> list = await query.ToListAsync();
            return ListResult(list, DbAction.Get);
        }

        public virtual DbResult<IEnumerable<TModel>> GetAll(Expression<Func<TModel, bool>> predicate)
        {
            var resultCode = ResultCode.Success;
            var query = Set.Where(predicate);
            return new DbResult<IEnumerable<TModel>>(resultCode, query);
        }

        public virtual async Task<DbResult<IEnumerable<TModel>>> GetAllAsync(Expression<Func<TModel, bool>> predicate)
        {
            var query = await Set.Where(predicate).ToListAsync();
            return ListResult(query, DbAction.Get);
        }

        public virtual DbResult<IEnumerable<TModel>> GetAllIncluding(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = Set.Where(predicate);
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return ListResult(query, DbAction.Get);
        }

        public virtual async Task<DbResult<IEnumerable<TModel>>> GetAllIncludingAsync(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = Set.Where(predicate);
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            IEnumerable<TModel> list = await query.ToListAsync();
            return ListResult(list, DbAction.Get);
        }

        public virtual DbResult<TModel> Find(Expression<Func<TModel, bool>> predicate)
        {
            var entity = Set.FirstOrDefault(predicate);
            return Result(entity, DbAction.Get);
        }

        public virtual async Task<DbResult<TModel>> FindAsync(Expression<Func<TModel, bool>> predicate)
        {
            var entity = await Set.FirstOrDefaultAsync(predicate);
            return Result(entity, DbAction.Get);
        }

        public virtual DbResult<TModel> Find(object id)
        {
            var entity = Set.Find(id);
            return Result(entity, DbAction.Get);
        }

        public virtual async Task<DbResult<TModel>> FindAsync(object id)
        {
            var entity = await Set.FindAsync(id);
            return Result(entity, DbAction.Get);
        }

        public virtual DbResult<TModel> InsertOrUpdate(TModel current)
        {
            TModel original = null;
            if (current.Id > 0)
            {
                original = Set.Find(current.Id);
                Context.Entry(original).CurrentValues.SetValues(current);
            }
            else
            {
                Set.Add(current);
            }

            var entity = original == null 
                ? Context.Entry(current).Entity
                : Context.Entry(original).Entity;
            return Result(entity, DbAction.Insert);
        }

        public virtual async Task<DbResult<TModel>> InsertOrUpdateAsync(TModel current)
        {
            TModel original = null;
            if (current.Id > 0)
            {
                var findResult = await FindAsync(current.Id);
                if (findResult.ResultCode == ResultCode.Failed)
                {
                    return Result(null, DbAction.General);
                }
                original = findResult.Content;
                Context.Entry(original).CurrentValues.SetValues(current);
            }
            else
            {
                Set.Add(current);
            }

            var entity = original == null 
                ? Context.Entry(current).Entity
                : Context.Entry(original).Entity;
            return Result(entity, DbAction.Insert);
        }

        public virtual DbResult<TModel> Delete(object id)
        {
            var entity = Set.Find(id);
            if (entity != null)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    Set.Attach(entity);
                }
                Set.Remove(entity);
            }
            return Result(entity, DbAction.Delete);
        }

        public virtual async Task<DbResult<TModel>> DeleteAsync(object id)
        {
            var entity = await Set.FindAsync(id);
            if (entity != null)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    Set.Attach(entity);
                }
                Set.Remove(entity);
            }
            return Result(entity, DbAction.Delete);
        }

        public ResultCode Save()
        {
            var result = ResultCode.SaveSuccessful;
            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                result = ResultCode.SaveFailed;
            }
            catch (DbEntityValidationException ex)
            {
                result = ResultCode.SaveFailed;
            }
            catch (Exception ex)
            {
                result = ResultCode.SaveFailed;
            }
            return result;
        }

        public async Task<ResultCode> SaveAsync()
        {
            var result = ResultCode.SaveSuccessful;
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                result = ResultCode.SaveFailed;
            }
            catch (DbEntityValidationException ex)
            {
                result = ResultCode.SaveFailed;
            }
            catch (Exception ex)
            {
                result = ResultCode.SaveFailed;
            }
            return result;
        }

        protected DbResult<TModel> Result(TModel item, DbAction action)
        {
            var resultCode = ResultCode.Success;
            switch (action)
            {
                case DbAction.General:
                    resultCode = item == null ? ResultCode.Failed : ResultCode.Success;
                    break;
                case DbAction.Get:
                    resultCode = item == null ? ResultCode.RecordNotFound : ResultCode.RecordFound;
                    break;
                case DbAction.Insert:
                    resultCode = item == null ? ResultCode.InsertFailed : ResultCode.InsertSuccessful;
                    break;
                case DbAction.Update:
                    resultCode = item == null ? ResultCode.UpdateFailed : ResultCode.UpdateSuccessful;
                    break;
                case DbAction.Delete:
                    resultCode = item == null ? ResultCode.DeleteFailed : ResultCode.DeleteSuccessful;
                    break;
                case DbAction.Save:
                    resultCode = item == null ? ResultCode.SaveFailed : ResultCode.SaveSuccessful;
                    break;
            }
            return new DbResult<TModel>(resultCode, item);
        }

        protected DbResult<IEnumerable<TModel>> ListResult(IEnumerable<TModel> item, DbAction action)
        {
            var resultCode = ResultCode.Success;
            var enumerable = item as TModel[] ?? item.ToArray();
            switch (action)
            {
                case DbAction.General:
                    resultCode = !enumerable.Any() ? ResultCode.Failed : ResultCode.Success;
                    break;
                case DbAction.Get:
                    resultCode = !enumerable.Any() ? ResultCode.RecordNotFound : ResultCode.RecordFound;
                    break;
                case DbAction.Insert:
                    resultCode = !enumerable.Any() ? ResultCode.InsertFailed : ResultCode.InsertSuccessful;
                    break;
                case DbAction.Update:
                    resultCode = !enumerable.Any() ? ResultCode.UpdateFailed : ResultCode.UpdateSuccessful;
                    break;
                case DbAction.Delete:
                    resultCode = !enumerable.Any() ? ResultCode.DeleteFailed : ResultCode.DeleteSuccessful;
                    break;
                case DbAction.Save:
                    resultCode = !enumerable.Any() ? ResultCode.Failed : ResultCode.Success;
                    break;
            }
            return new DbResult<IEnumerable<TModel>>(resultCode, enumerable);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
