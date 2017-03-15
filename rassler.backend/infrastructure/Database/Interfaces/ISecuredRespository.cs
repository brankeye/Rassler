using rassler.backend.domain.Model.Interfaces;

namespace rassler.backend.infrastructure.Database.Interfaces
{
    public interface ISecuredRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        void Initialize(string username);
    }
}
