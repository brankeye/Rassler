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
    public class StandingsController : CoreController<Standing>
    {
        public StandingsController(IUnitOfWork unitOfWork, IMapper mapper, IHttpStatusCodeParser parser)
            : base(mapper, parser)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Standing>))]
        public async Task<IHttpActionResult> Get()
        {
            var standings = await UnitOfWork.Standings.GetAllAsync();
            var response = GetResponse(standings);
            return response;
        }

        [HttpGet]
        [ResponseType(typeof(Standing))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var standings = await UnitOfWork.Standings.FindAsync(id);
            var response = GetResponse(standings);
            return response;
        }
    }
}