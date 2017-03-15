using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services.Repositories
{
    public class PaymentsRepository : SecuredRepository<Payment>, IPaymentsRepository
    {
        public PaymentsRepository(DbContext context) : base(context)
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
