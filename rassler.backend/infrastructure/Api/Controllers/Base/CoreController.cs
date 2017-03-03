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
        protected IHttpActionResult GetResponse<TModel>(DbResult<TModel> result)
        {
            return GetResponse(result.ResultCode, result.Content);
        }

        protected IHttpActionResult GetResponse(ResultCode resultCode)
        {
            var statusCode = GetStatusCodeParser().GetStatusCode(resultCode);
            var response = Request.CreateResponse(statusCode);
            return ResponseMessage(response);
        }

        protected IHttpActionResult GetResponse<TModel>(ResultCode resultCode, TModel content)
        {
            var statusCode = GetStatusCodeParser().GetStatusCode(resultCode);
            var response = Request.CreateResponse(statusCode, content);
            return ResponseMessage(response);
        }

        protected IHttpActionResult GetResponse(HttpStatusCode statusCode)
        {
            var response = Request.CreateResponse(statusCode);
            return ResponseMessage(response);
        }

        protected ISecuredRepository<TModel> GetSecuredRepository<TModel>()
            where TModel : class
        {
            var repository = (ISecuredRepository<TModel>)Request.GetDependencyScope().GetService(typeof(ISecuredRepository<TModel>));
            repository.Initialize(GetUsername());
            return repository;
        }

        protected IRepository<TModel> GetRepository<TModel>()
            where TModel : class
        {
            return (IRepository<TModel>)Request.GetDependencyScope().GetService(typeof(IRepository<TModel>));
        }

        protected IHttpStatusCodeParser GetStatusCodeParser()
        {
            return (IHttpStatusCodeParser)Request.GetDependencyScope().GetService(typeof(IHttpStatusCodeParser));
        }

        protected IMapper GetMapper()
        {
            return (IMapper)Request.GetDependencyScope().GetService(typeof(IMapper));
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
