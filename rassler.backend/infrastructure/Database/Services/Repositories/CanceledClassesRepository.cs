using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services.Repositories
{
    public class CanceledClassesRepository : SecuredRepository<CanceledClass>, ICanceledClassesRepository
    {
        public CanceledClassesRepository(DbContext context) : base(context)
        {

        }

        protected override bool CanDelete(object id)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanDeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        protected override bool CanFind(CanceledClass item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(CanceledClass item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<CanceledClass> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(CanceledClass item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(CanceledClass item)
        {
            throw new NotImplementedException();
        }
    }
}
