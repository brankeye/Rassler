using rassler.backend.domain.Data.Interfaces;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database
{
    public class Repository<TModel> : Repository<infrastructure.Database.Context, TModel>
        where TModel : class, IEntity
    {
        
    }
}
