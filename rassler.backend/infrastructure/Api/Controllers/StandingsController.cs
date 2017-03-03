using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Api.Controllers.Base;

namespace rassler.backend.infrastructure.Api.Controllers
{
    public class StandingsController : CoreController<Standing>
    {
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Standing>))]
        public async Task<IHttpActionResult> Get()
        {
            var usersRepository = GetRepository<Standing>();
            var users = await usersRepository.GetAllAsync();
            var response = GetResponse(users);
            return response;
        }

        [HttpGet]
        [ResponseType(typeof(Standing))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var usersRepository = GetRepository<Standing>();
            var users = await usersRepository.FindAsync(id);
            var response = GetResponse(users);
            return response;
        }
    }
}