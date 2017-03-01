using System;

namespace rassler.backend.domain.Data.Interfaces
{
    public interface IDateInfo
    {
        DateTimeOffset? DateCreated { get; set; }

        DateTimeOffset? DateModified { get; set; }
    }
}
