using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.backend.domain.Data.Configurations
{
    public class ClassConfiguration : EntityTypeConfiguration<Model.Class>
    {
        public ClassConfiguration()
        {
            HasRequired(x => x.School).WithMany(x => x.Classes).HasForeignKey(x => x.SchoolId);
        }
    }
}
