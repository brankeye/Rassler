using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using rassler.backend.infrastructure.Api.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Objects;

namespace rassler.backend.infrastructure.Api.Controllers.Base
{
    public class CoreController<T> : ApiController
        where T : class
    {
        protected IHttpActionResult GetResponse<TModel>(DbResult<TModel> result)
            where TModel : class
        {
            var statusCode = GetStatusCodeParser().GetStatusCode(result.ResultCode);
            var response = Request.CreateResponse(statusCode, result.Content);
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
