namespace rassler.backend.infrastructure.Database.Interfaces
{
    public interface ISecuredRepository<T> : IRepository<T>
        where T : class
    {
        void Initialize(string username);
    }
}
