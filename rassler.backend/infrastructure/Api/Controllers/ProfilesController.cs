using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using rassler.backend.domain.Data.Models;
using rassler.backend.domain.Data.Models.Base;
using rassler.backend.infrastructure.Api.Controllers.Base;

namespace rassler.backend.infrastructure.Api.Controllers
{
    public class ProfilesController : CoreController<Profile>
    {
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Profile>))]
        public async Task<IHttpActionResult> Get()
        {
            var repository = GetSecuredRepository<Profile>();
            var entities = await repository.GetAllAsync();
            var response = GetResponse(entities);
            return response;
        }

        [HttpGet]
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var repository = GetSecuredRepository<Profile>();
            var entity = await repository.FindAsync(id);
            var response = GetResponse(entity);
            return response;
        }

        [HttpPost]
        [ResponseType(typeof(Entity))]
        public async Task<IHttpActionResult> Post([FromBody] domain.Data.Models.DTOs.Profile entity)
        {
            if (ModelState.IsValid)
            {
                var repository = GetSecuredRepository<Profile>();
                var mapper = GetMapper();
                var mappedEntity = mapper.Map<domain.Data.Models.Profile>(entity);
                var updatedEntity = await repository.InsertOrUpdateAsync(mappedEntity);
                var response = GetResponse(updatedEntity.ResultCode, (Entity) updatedEntity.Content);
                return response;
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long id)
        {
            var repository = GetSecuredRepository<Profile>();
            var deletedEntity = await repository.DeleteAsync(id);
            var response = GetResponse(deletedEntity.ResultCode);
            return response;
        }
    }
}