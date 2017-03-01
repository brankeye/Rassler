namespace rassler.backend.domain.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsAttending = c.Boolean(nullable: false),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        ClassId = c.Long(nullable: false),
                        ProfileId = c.Long(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ClassId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Day = c.String(),
                        StartTime = c.DateTimeOffset(nullable: false, precision: 7),
                        EndTime = c.DateTimeOffset(nullable: false, precision: 7),
                        SchoolId = c.Long(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.CanceledClasses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        IsCanceled = c.Boolean(nullable: false),
                        ClassId = c.Long(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        PhoneNumber = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsActive = c.Boolean(nullable: false),
                        ContactInfoId = c.Long(nullable: false),
                        StandingId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        SchoolId = c.Long(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .ForeignKey("dbo.Standings", t => t.StandingId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.StandingId)
                .Index(t => t.UserId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        StartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        EndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ProfileId = c.Long(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        AchievementDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ProfileId = c.Long(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Standings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Level = c.Int(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttendanceRecords", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Profiles", "StandingId", "dbo.Standings");
            DropForeignKey("dbo.Profiles", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Ranks", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Payments", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.ContactInfoes", "Id", "dbo.Profiles");
            DropForeignKey("dbo.Classes", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.CanceledClasses", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.AttendanceRecords", "ClassId", "dbo.Classes");
            DropIndex("dbo.Ranks", new[] { "ProfileId" });
            DropIndex("dbo.Payments", new[] { "ProfileId" });
            DropIndex("dbo.ContactInfoes", new[] { "Id" });
            DropIndex("dbo.Profiles", new[] { "SchoolId" });
            DropIndex("dbo.Profiles", new[] { "UserId" });
            DropIndex("dbo.Profiles", new[] { "StandingId" });
            DropIndex("dbo.CanceledClasses", new[] { "ClassId" });
            DropIndex("dbo.Classes", new[] { "SchoolId" });
            DropIndex("dbo.AttendanceRecords", new[] { "ProfileId" });
            DropIndex("dbo.AttendanceRecords", new[] { "ClassId" });
            DropTable("dbo.Users");
            DropTable("dbo.Standings");
            DropTable("dbo.Ranks");
            DropTable("dbo.Payments");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.Profiles");
            DropTable("dbo.Schools");
            DropTable("dbo.CanceledClasses");
            DropTable("dbo.Classes");
            DropTable("dbo.AttendanceRecords");
        }
    }
}
