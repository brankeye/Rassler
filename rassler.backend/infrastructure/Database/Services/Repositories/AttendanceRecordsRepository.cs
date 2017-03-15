using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services.Repositories
{
    public class AttendanceRecordsRepository : SecuredRepository<AttendanceRecord>, IAttendanceRecordsRepository
    {
        public AttendanceRecordsRepository(DbContext context) : base(context)
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
