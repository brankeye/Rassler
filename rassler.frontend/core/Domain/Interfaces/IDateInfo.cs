using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.frontend.core.Domain.Interfaces
{
    public interface IDateInfo
    {
        DateTimeOffset? DateCreated { get; set; }

        DateTimeOffset? DateModified { get; set; }
    }
}
