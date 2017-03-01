using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.Models.Base;

namespace rassler.backend.domain.Data.Models
{
    [DataContract]
    public class Class : Entity
    {
        public Class()
        {
            CanceledClasses = new List<CanceledClass>();
            AttendanceRecords = new List<AttendanceRecord>();
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Day { get; set; }

        [DataMember]
        public DateTimeOffset StartTime { get; set; }

        [DataMember]
        public DateTimeOffset EndTime { get; set; }

        [ForeignKey(nameof(SchoolId))]
        public virtual School School { get; set; }

        [DataMember]
        public long SchoolId { get; set; }

        public virtual ICollection<CanceledClass> CanceledClasses { get; set; }

        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; }
    }
}
