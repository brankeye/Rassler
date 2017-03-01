using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services
{
    public class UsersRepository : SecuredRepository<Context, User>
    {
        protected override bool CanFind(User item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(User item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<User> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(User item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(User item)
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
