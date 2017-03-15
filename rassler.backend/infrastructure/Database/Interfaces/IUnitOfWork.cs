using System;
using System.Threading.Tasks;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;

namespace rassler.backend.infrastructure.Database.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStandingsRepository Standings { get; }

        IAttendanceRecordsRepository AttendanceRecords { get; }

        ICanceledClassesRepository CanceledClasses { get; }

        IClassesRepository Classes { get; }

        IContactInfosRepository ContactInfos { get; }

        IPaymentsRepository Payments { get; }

        IProfilesRepository Profiles { get; }

        IRanksRepository Ranks { get; }

        ISchoolsRepository Schools { get; }

        IUsersRepository Users { get; }

        void Commit();

        Task CommitAsync();
    }
}
