using System;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services
{
    public class SchoolsRepository : SecuredRepository<Context, School>
    {
        protected override bool CanDelete(object id)
        {
            var school = Context.Schools.Find(id);
            if (school == null) return false;
            var headInstructorLevel = (int) domain.Data.Enums.Standing.HeadInstructor;
            var members = school.Members.Where(x => x.Standing.Level == headInstructorLevel);
            var canDelete = members.Any(x => x.User.Username == Username);
            return canDelete;
        }

        protected override Task<bool> CanDeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        protected override bool CanFind(School item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(School item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<School> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(School item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(School item)
        {
            throw new NotImplementedException();
        }
    }
}
