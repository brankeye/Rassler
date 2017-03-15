using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services.Repositories
{
    public class ProfilesRepository : SecuredRepository<Profile>, IProfilesRepository
    {
        public ProfilesRepository(DbContext context) : base(context)
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

        protected override bool CanFind(Profile item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(Profile item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<Profile> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(Profile item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(Profile item)
        {
            throw new NotImplementedException();
        }
    }
}
