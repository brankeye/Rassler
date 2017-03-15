using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.backend.domain.Data.Configurations
{
    public class SchoolConfiguration : EntityTypeConfiguration<Model.School>
    {
        public SchoolConfiguration()
        {
            HasRequired(x => x.Owner).WithRequiredPrincipal(x => x.School);
        }
    }
}
