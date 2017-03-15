using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.backend.domain.Data.Configurations
{
    public class RankConfiguration : EntityTypeConfiguration<Model.Rank>
    {
        public RankConfiguration()
        {
            HasRequired(x => x.Profile).WithMany(x => x.Ranks).HasForeignKey(x => x.ProfileId);
        }
    }
}
