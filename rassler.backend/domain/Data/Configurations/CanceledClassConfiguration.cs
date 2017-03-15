using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.backend.domain.Data.Configurations
{
    public class CanceledClassConfiguration : EntityTypeConfiguration<Model.CanceledClass>
    {
        public CanceledClassConfiguration()
        {
            HasRequired(x => x.Class).WithMany(x => x.CanceledClasses).HasForeignKey(x => x.ClassId);
        }
    }
}
