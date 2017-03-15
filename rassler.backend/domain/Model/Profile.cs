using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace rassler.backend.domain.Model
{
    [DataContract]
    public class Profile : Entity
    {
        public Profile()
        {
            Ranks = new List<Rank>();
            Payments = new List<Payment>();
        }

        [DataMember]
        public DateTimeOffset StartDate { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
        
        public virtual ContactInfo ContactInfo { get; set; }

        [DataMember]
        public long ContactInfoId { get; set; }
        
        public virtual Standing Standing { get; set; }

        [DataMember]
        public long StandingId { get; set; }
        
        public virtual User User { get; set; }

        [DataMember]
        public long UserId { get; set; }
        
        public virtual School School { get; set; }

        [DataMember]
        public long SchoolId { get; set; }

        public virtual ICollection<Rank> Ranks { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; }
    }
}
