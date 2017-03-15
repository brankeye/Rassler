using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.backend.domain.Data.Configurations
{
    public class ProfileConfiguration : EntityTypeConfiguration<Model.Profile>
    {
        public ProfileConfiguration()
        {
            HasRequired(x => x.ContactInfo).WithRequiredPrincipal(x => x.Profile);
            HasOptional(x => x.User).WithMany(x => x.Profiles).HasForeignKey(x => x.UserId);
            HasRequired(x => x.School).WithMany(x => x.Members).HasForeignKey(x => x.SchoolId);
            HasRequired(x => x.Standing);
        }
    }
}
