using System.Threading.Tasks;
using System.Web.Http;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Api.Controllers.Base;

namespace rassler.backend.infrastructure.Api.Controllers
{
    public class PaymentsController : CoreController<Payment>
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var paymentsRepository = GetSecuredRepository<Payment>();
            var payments = await paymentsRepository.GetAllAsync();
            var response = GetResponse(payments);
            return response;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(long id)
        {
            var paymentsRepository = GetSecuredRepository<Payment>();
            var payment = await paymentsRepository.FindAsync(id);
            var response = GetResponse(payment);
            return response;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Payment entity)
        {
            if (ModelState.IsValid)
            {
                var paymentsRepository = GetSecuredRepository<Payment>();
                var updatedPayment = await paymentsRepository.InsertOrUpdateAsync(entity);
                var response = GetResponse(updatedPayment);
                return response;
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(long id)
        {
            var paymentsRepository = GetSecuredRepository<Payment>();
            var deletedPayment = await paymentsRepository.DeleteAsync(id);
            var response = GetResponse(deletedPayment);
            return response;
        }
    }
}