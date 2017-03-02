using System;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services
{
    public class PaymentsRepository : SecuredRepository<Context, Payment>
    {
        protected override bool CanDelete(object id)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanDeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        protected override bool CanFind(Payment item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(Payment item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<Payment> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(Payment item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(Payment item)
        {
            throw new NotImplementedException();
        }
    }
}
