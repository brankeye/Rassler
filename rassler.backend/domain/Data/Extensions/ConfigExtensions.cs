using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.backend.domain.Data.Extensions
{
    public static class ConfigExtensions
    {
        public static PrimitivePropertyConfiguration IsIndexed(this PrimitivePropertyConfiguration config, bool isUnique = false)
        {
            return config.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute { IsUnique = isUnique }));
        }
    }
}
