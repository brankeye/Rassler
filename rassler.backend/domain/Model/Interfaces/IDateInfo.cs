using System;

namespace rassler.backend.domain.Model.Interfaces
{
    public interface IDateInfo
    {
        DateTimeOffset? DateCreated { get; set; }

        DateTimeOffset? DateModified { get; set; }
    }
}
