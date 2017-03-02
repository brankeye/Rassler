using System.Threading.Tasks;
using System.Web.Http;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Api.Controllers.Base;

namespace rassler.backend.infrastructure.Api.Controllers
{
    public class UsersController : CoreController<User>
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get(long id)
        {
            var usersRepository = GetSecuredRepository<User>();
            var users = await usersRepository.FindAsync(id);
            var response = GetResponse(users);
            return response;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] User entity)
        {
            if (ModelState.IsValid)
            {
                var usersRepository = GetSecuredRepository<User>();
                var user = await usersRepository.InsertOrUpdateAsync(entity);
                var response = GetResponse(user);
                return response;
            }
            return BadRequest();
        }
    }
}