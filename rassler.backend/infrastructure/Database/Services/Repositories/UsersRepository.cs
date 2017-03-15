using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services.Repositories
{
    public class UsersRepository : SecuredRepository<User>, IUsersRepository
    {
        public UsersRepository(DbContext context) : base(context)
        {

        }

        protected override bool CanFind(User item)
        {
            return item.Username == Username;
        }

        protected override Task<bool> CanFindAsync(User item)
        {
            var result = item.Username == Username;
            return Task.FromResult(result);
        }

        protected override bool CanGet(out IQueryable<User> list)
        {
            var user = Set.FirstOrDefault(x => x.Username == Username);
            var users = new List<User>();
            if (user != null)
            {
                users.Add(user);
            }
            list = new EnumerableQuery<User>(users);
            return true;
        }

        protected override bool CanInsert(User item)
        {
            var existingItem = Find(x => x.Username == item.Username);
            var canInsert = existingItem == null && item.Username == Username;
            return canInsert;
        }

        protected override async Task<bool> CanInsertAsync(User item)
        {
            var existingItem = await FindAsync(x => x.Username == item.Username);
            var canInsert = existingItem == null && item.Username == Username;
            return canInsert;
        }

        protected override bool CanDelete(object id)
        {
            return false;
        }

        protected override Task<bool> CanDeleteAsync(object id)
        {
            return Task.FromResult(false);
        }
    }
}
