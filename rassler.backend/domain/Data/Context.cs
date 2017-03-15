using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Configurations;
using rassler.backend.domain.Model.Interfaces;

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

            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(200));

            modelBuilder.Configurations.Add(new AttendanceRecordConfiguration());
            modelBuilder.Configurations.Add(new CanceledClassConfiguration());
            modelBuilder.Configurations.Add(new ClassConfiguration());
            modelBuilder.Configurations.Add(new PaymentConfiguration());
            modelBuilder.Configurations.Add(new ProfileConfiguration());
            modelBuilder.Configurations.Add(new RankConfiguration());
            modelBuilder.Configurations.Add(new SchoolConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
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

        public DbSet<Model.User> Users { get; set; }

        public DbSet<Model.AttendanceRecord> AttendanceRecords { get; set; }

        public DbSet<Model.CanceledClass> CanceledClasses { get; set; }

        public DbSet<Model.Class> Classes { get; set; }

        public DbSet<Model.Profile> Profiles { get; set; }

        public DbSet<Model.School> Schools { get; set; }

        public DbSet<Model.Payment> Payments { get; set; }

        public DbSet<Model.Standing> Standings { get; set; }

        public DbSet<Model.Rank> Ranks { get; set; }

        public DbSet<Model.ContactInfo> ContactInfos { get; set; }
    }
}
