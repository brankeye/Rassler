using System.Collections.Generic;
using System.Net;
using rassler.backend.domain.Data.Enums;

namespace rassler.backend.infrastructure.Api.Utilities
{
    public class HttpStatusCodeMapping
    {
        public IDictionary<ResultCode, HttpStatusCode> Dictionary { get; set; }

        public HttpStatusCodeMapping()
        {
            Dictionary = new Dictionary<ResultCode, HttpStatusCode>()
            {
                { ResultCode.DeleteFailed, HttpStatusCode.InternalServerError },
                { ResultCode.DeleteSuccessful, HttpStatusCode.OK },
                { ResultCode.InsertFailed, HttpStatusCode.InternalServerError },
                { ResultCode.InsertSuccessful, HttpStatusCode.OK },
                { ResultCode.RecordFound, HttpStatusCode.OK },
                { ResultCode.RecordNotFound, HttpStatusCode.NotFound },
                { ResultCode.SaveFailed, HttpStatusCode.InternalServerError },
                { ResultCode.SaveSuccessful, HttpStatusCode.OK },
                { ResultCode.Success, HttpStatusCode.OK },
                { ResultCode.Failed, HttpStatusCode.InternalServerError },
                { ResultCode.UpdateFailed, HttpStatusCode.InternalServerError },
                { ResultCode.UpdateSuccessful, HttpStatusCode.OK },
                { ResultCode.Authorized, HttpStatusCode.OK },
                { ResultCode.Unauthorized, HttpStatusCode.Unauthorized }
            };
        }
    }
}