using System.Threading.Tasks;
using System.Web.Http;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Api.Controllers.Base;

namespace rassler.backend.infrastructure.Api.Controllers
{
    public class AttendanceRecordsController : CoreController<AttendanceRecord>
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var repository = GetSecuredRepository<AttendanceRecord>();
            var entities = await repository.GetAllAsync();
            var response = GetResponse(entities);
            return response;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(long id)
        {
            var repository = GetSecuredRepository<AttendanceRecord>();
            var entity = await repository.FindAsync(id);
            var response = GetResponse(entity);
            return response;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] AttendanceRecord entity)
        {
            if (ModelState.IsValid)
            {
                var repository = GetSecuredRepository<AttendanceRecord>();
                var updatedEntity = await repository.InsertOrUpdateAsync(entity);
                var response = GetResponse(updatedEntity);
                return response;
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(long id)
        {
            var repository = GetSecuredRepository<AttendanceRecord>();
            var deletedEntity = await repository.DeleteAsync(id);
            var response = GetResponse(deletedEntity);
            return response;
        }
    }
}