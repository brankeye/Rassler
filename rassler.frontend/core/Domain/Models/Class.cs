using System;
using System.Linq;
using System.Runtime.Serialization;
using rassler.frontend.core.Domain.Interfaces;
using Realms;
using Xamarin.Realm.Service.Attributes;

namespace rassler.frontend.core.Domain.Models
{
    [DataContract]
    public class Class : RealmObject, ILocalEntity
    {
        [PrimaryKey, AutoIncrement]
        public long LocalId { get; set; }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTimeOffset DateTime { get; set; }

        [DataMember]
        public double Minutes { get; set; }

        [DataMember]
        public long SchoolId { get; set; }

        public School School { get; set; }

        [Backlink(nameof(CanceledClass.Class))]
        public IQueryable<CanceledClass> CanceledClasses { get; }

        [Backlink(nameof(AttendanceRecord.Class))]
        public IQueryable<AttendanceRecord> AttendanceRecords { get; }

        public DateTimeOffset? DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}
