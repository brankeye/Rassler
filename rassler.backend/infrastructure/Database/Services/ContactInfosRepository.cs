using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services
{
    public class ContactInfosRepository : SecuredRepository<Context, ContactInfo>
    {
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
