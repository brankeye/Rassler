using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Interfaces;

namespace rassler.backend.domain.Data
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public override int SaveChanges()
        {
            HandleTracking();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            HandleTracking();
            return base.SaveChangesAsync();
        }

        protected void HandleTracking()
        {
            var changedEntities = ChangeTracker.Entries<IDateInfo>();
            foreach (var entry in changedEntities)
            {
                var entity = entry.Entity;
                var nowDate = DateTimeOffset.UtcNow;
                if (entry.State == EntityState.Added)
                {
                    entity.DateCreated = nowDate;
                    entity.DateModified = nowDate;
                }
                else if (entry.State == EntityState.Modified)
                {
                    var originalDateCreated = entry.OriginalValues.GetValue<DateTimeOffset?>(nameof(entity.DateCreated));
                    entity.DateCreated = originalDateCreated;
                    entity.DateModified = nowDate;
                }
            }
        }

        public DbSet<Models.User> Users { get; set; }

        public DbSet<Models.AttendanceRecord> AttendanceRecords { get; set; }

        public DbSet<Models.CanceledClass> CanceledClasses { get; set; }

        public DbSet<Models.Class> Classes { get; set; }

        public DbSet<Models.Profile> Profiles { get; set; }

        public DbSet<Models.School> Schools { get; set; }

        public DbSet<Models.Payment> Payments { get; set; }

        public DbSet<Models.Standing> Standings { get; set; }

        public DbSet<Models.Rank> Ranks { get; set; }

        public DbSet<Models.ContactInfo> ContactInfos { get; set; }
    }
}
