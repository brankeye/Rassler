using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services
{
    public class CanceledClassesRepository : SecuredRepository<Context, CanceledClass>
    {
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
