using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using rassler.backend.domain.Data.Interfaces;
using rassler.backend.domain.Data.Models;
using rassler.backend.domain.Data.Models.Base;
using rassler.backend.infrastructure.Api.Controllers.Base;

namespace rassler.backend.infrastructure.Api.Controllers
{
    public class UsersController : CoreController<User>
    {
        [HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var usersRepository = GetSecuredRepository<User>();
            var users = await usersRepository.FindAsync(id);
            var response = GetResponse(users);
            return response;
        }

        [HttpPost]
        [ResponseType(typeof(Entity))]
        public async Task<IHttpActionResult> Post([FromBody] domain.Data.Models.DTOs.User entity)
        {
            if (ModelState.IsValid)
            {
                var repository = GetSecuredRepository<User>();
                var mapper = GetMapper();
                var mappedEntity = mapper.Map<domain.Data.Models.User>(entity);
                var updatedEntity = await repository.InsertOrUpdateAsync(mappedEntity);
                var response = GetResponse(updatedEntity.ResultCode, (Entity) updatedEntity.Content );
                return response;
            }
            return BadRequest();
        }
    }
}