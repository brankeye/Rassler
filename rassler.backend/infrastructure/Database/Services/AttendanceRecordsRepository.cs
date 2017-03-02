using System;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services
{
    public class AttendanceRecordsRepository : SecuredRepository<Context, AttendanceRecord>
    {
        protected override bool CanDelete(object id)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanDeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        protected override bool CanFind(AttendanceRecord item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(AttendanceRecord item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<AttendanceRecord> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(AttendanceRecord item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(AttendanceRecord item)
        {
            throw new NotImplementedException();
        }
    }
}
