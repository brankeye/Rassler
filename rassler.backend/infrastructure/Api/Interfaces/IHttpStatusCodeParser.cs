using System.Net;
using rassler.backend.domain.Data.Enums;

namespace rassler.backend.infrastructure.Api.Interfaces
{
    public interface IHttpStatusCodeParser
    {
        HttpStatusCode GetStatusCode(ResultCode resultCode);
    }
}
