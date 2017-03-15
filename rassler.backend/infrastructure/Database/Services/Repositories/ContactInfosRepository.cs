using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services.Repositories
{
    public class ContactInfosRepository : SecuredRepository<ContactInfo>, IContactInfosRepository
    {
        public ContactInfosRepository(DbContext context) : base(context)
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

        protected override bool CanFind(ContactInfo item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(ContactInfo item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<ContactInfo> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(ContactInfo item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(ContactInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
