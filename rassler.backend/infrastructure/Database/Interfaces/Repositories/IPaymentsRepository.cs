using rassler.backend.domain.Model;

namespace rassler.backend.infrastructure.Database.Interfaces.Repositories
{
    public interface IPaymentsRepository : ISecuredRepository<Payment>
    {
    }
}
