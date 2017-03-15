using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Api.Controllers.Base;
using rassler.backend.infrastructure.Api.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces;

namespace rassler.backend.infrastructure.Api.Controllers
{
    public class ProfilesController : CoreController<domain.Model.Profile>
    {
        public ProfilesController(IUnitOfWork unitOfWork, IMapper mapper, IHttpStatusCodeParser parser)
            : base(mapper, parser)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<domain.Model.Profile>))]
        public async Task<IHttpActionResult> Get()
        {
            var entities = await UnitOfWork.Profiles.GetAllAsync();
            var response = GetResponse(entities);
            return response;
        }

        [HttpGet]
        [ResponseType(typeof(domain.Model.Profile))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var entity = await UnitOfWork.Profiles.FindAsync(id);
            var response = GetResponse(entity);
            return response;
        }

        [HttpPost]
        [ResponseType(typeof(Entity))]
        public async Task<IHttpActionResult> Post([FromBody] domain.DTO.Profile entity)
        {
            if (ModelState.IsValid)
            {
                var mappedEntity = Mapper.Map<domain.Model.Profile>(entity);
                var updatedEntity = await UnitOfWork.Profiles.InsertOrUpdateAsync(mappedEntity);
                await UnitOfWork.CommitAsync();
                var response = GetResponse(updatedEntity.ResultCode, (Entity) updatedEntity.Content);
                return response;
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long id)
        {
            var deletedEntity = await UnitOfWork.Profiles.DeleteAsync(id);
            await UnitOfWork.CommitAsync();
            var response = GetResponse(deletedEntity.ResultCode);
            return response;
        }
    }
}