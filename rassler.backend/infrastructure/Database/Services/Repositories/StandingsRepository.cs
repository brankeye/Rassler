using System.Data.Entity;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services.Repositories
{
    public class StandingsRepository : Repository<Standing>, IStandingsRepository
    {
        public StandingsRepository(DbContext context) : base(context)
        {

        }
    }
}
