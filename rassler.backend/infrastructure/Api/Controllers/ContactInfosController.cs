using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Areas.HelpPage.ModelDescriptions;
using AutoMapper;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Api.Controllers.Base;
using rassler.backend.infrastructure.Api.Interfaces;
using rassler.backend.infrastructure.Database.Interfaces;

namespace rassler.backend.infrastructure.Api.Controllers
{
    public class ContactInfosController : CoreController<ContactInfo>
    {
        public ContactInfosController(IUnitOfWork unitOfWork, IMapper mapper, IHttpStatusCodeParser parser)
            : base(mapper, parser)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ContactInfo>))]
        public async Task<IHttpActionResult> Get()
        {
            var entities = await UnitOfWork.ContactInfos.GetAllAsync();
            var response = GetResponse(entities);
            return response;
        }
        
        [HttpGet]
        [ResponseType(typeof(ContactInfo))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var entity = await UnitOfWork.ContactInfos.FindAsync(id);
            var response = GetResponse(entity);
            return response;
        }

        [HttpPost]
        [ResponseType(typeof(Entity))]
        public async Task<IHttpActionResult> Post([FromBody] domain.DTO.ContactInfo entity)
        {
            if (ModelState.IsValid)
            {
                var mappedEntity = Mapper.Map<domain.Model.ContactInfo>(entity);
                var updatedEntity = await UnitOfWork.ContactInfos.InsertOrUpdateAsync(mappedEntity);
                await UnitOfWork.CommitAsync();
                var response = GetResponse(updatedEntity.ResultCode, (Entity) updatedEntity.Content);
                return response;
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long id)
        {
            var deletedEntity = await UnitOfWork.ContactInfos.DeleteAsync(id);
            await UnitOfWork.CommitAsync();
            var response = GetResponse(deletedEntity.ResultCode);
            return response;
        }
    }
}