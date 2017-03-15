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
    public class CanceledClassesController : CoreController<CanceledClass>
    {
        public CanceledClassesController(IUnitOfWork unitOfWork, IMapper mapper, IHttpStatusCodeParser parser)
            : base(mapper, parser)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<CanceledClass>))]
        public async Task<IHttpActionResult> Get()
        {
            var entities = await UnitOfWork.CanceledClasses.GetAllAsync();
            var response = GetResponse(entities);
            return response;
        }

        [HttpGet]
        [ResponseType(typeof(CanceledClass))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var entity = await UnitOfWork.CanceledClasses.FindAsync(id);
            var response = GetResponse(entity);
            return response;
        }

        [HttpPost]
        [ResponseType(typeof(Entity))]
        public async Task<IHttpActionResult> Post([FromBody] domain.DTO.CanceledClass entity)
        {
            if (ModelState.IsValid)
            {
                var mappedEntity = Mapper.Map<domain.Model.CanceledClass>(entity);
                var updatedEntity = await UnitOfWork.CanceledClasses.InsertOrUpdateAsync(mappedEntity);
                await UnitOfWork.CommitAsync();
                var response = GetResponse(updatedEntity.ResultCode, (Entity) updatedEntity.Content);
                return response;
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long id)
        {
            var deletedEntity = await UnitOfWork.CanceledClasses.DeleteAsync(id);
            await UnitOfWork.CommitAsync();
            var response = GetResponse(deletedEntity.ResultCode);
            return response;
        }
    }
}