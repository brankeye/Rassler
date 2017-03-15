using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.backend.domain.Data.Configurations
{
    public class PaymentConfiguration : EntityTypeConfiguration<Model.Payment>
    {
        public PaymentConfiguration()
        {
            HasRequired(x => x.Profile).WithMany(x => x.Payments).HasForeignKey(x => x.ProfileId);
        }
    }
}
