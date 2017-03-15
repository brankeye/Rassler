using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Extensions;

namespace rassler.backend.domain.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<Model.User>
    {
        public UserConfiguration()
        {
            Property(x => x.Username).IsRequired().IsIndexed(true);
        }
    }
}
