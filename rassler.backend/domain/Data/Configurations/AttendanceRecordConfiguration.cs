using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.backend.domain.Data.Configurations
{
    public class AttendanceRecordConfiguration : EntityTypeConfiguration<Model.AttendanceRecord>
    {
        public AttendanceRecordConfiguration()
        {
            HasRequired(x => x.Class).WithMany(x => x.AttendanceRecords).HasForeignKey(x => x.ClassId);
            HasRequired(x => x.Profile).WithMany(x => x.AttendanceRecords).HasForeignKey(x => x.ProfileId);
        }
    }
}
