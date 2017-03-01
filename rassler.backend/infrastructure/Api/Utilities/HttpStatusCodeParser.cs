using System.Net;
using Ninject;
using rassler.backend.domain.Data.Enums;
using rassler.backend.infrastructure.Api.Interfaces;

namespace rassler.backend.infrastructure.Api.Utilities
{
    public class HttpStatusCodeParser : IHttpStatusCodeParser
    {
        protected HttpStatusCodeMapping StatusCodeMapping { get; set; }

        [Inject]
        public HttpStatusCodeParser(HttpStatusCodeMapping statusCodeMapping)
        {
            StatusCodeMapping = statusCodeMapping;
        }

        public HttpStatusCode GetStatusCode(ResultCode resultCode)
        {
            HttpStatusCode statusCode;
            StatusCodeMapping.Dictionary.TryGetValue(resultCode, out statusCode);
            return statusCode;
        }
    }
}