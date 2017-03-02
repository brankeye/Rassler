using System;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services
{
    public class ClassesRepository : SecuredRepository<Context, Class>
    {
        protected override bool CanFind(Class item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(Class item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<Class> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(Class item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(Class item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDelete(object id)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanDeleteAsync(object id)
        {
            throw new NotImplementedException();
        }
    }
}
