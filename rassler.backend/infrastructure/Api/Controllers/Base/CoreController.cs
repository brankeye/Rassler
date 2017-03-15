using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using rassler.backend.domain.Data.Enums;
using rassler.backend.infrastructure.Api.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Objects;

namespace rassler.backend.infrastructure.Api.Controllers.Base
{
    public class CoreController<T> : ApiController
        where T : class
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected IMapper Mapper { get; set; }

        protected IHttpStatusCodeParser StatusCodeParser { get; set; }

        public CoreController(IMapper mapper, IHttpStatusCodeParser parser)
        {
            Mapper = mapper;
            StatusCodeParser = parser;
        }

        protected IHttpActionResult GetResponse<TModel>(DbResult<TModel> result)
        {
            return GetResponse(result.ResultCode, result.Content);
        }

        protected IHttpActionResult GetResponse(ResultCode resultCode)
        {
            var statusCode = StatusCodeParser.GetStatusCode(resultCode);
            var response = Request.CreateResponse(statusCode);
            return ResponseMessage(response);
        }

        protected IHttpActionResult GetResponse<TModel>(ResultCode resultCode, TModel content)
        {
            var statusCode = StatusCodeParser.GetStatusCode(resultCode);
            var response = Request.CreateResponse(statusCode, content);
            return ResponseMessage(response);
        }

        protected IHttpActionResult GetResponse(HttpStatusCode statusCode)
        {
            var response = Request.CreateResponse(statusCode);
            return ResponseMessage(response);
        }

        protected string GetUsername()
        {
            return RequestContext.Principal.Identity.GetUserName();
        }

        protected string GetUserId()
        {
            return RequestContext.Principal.Identity.GetUserId();
        }
    }
}
