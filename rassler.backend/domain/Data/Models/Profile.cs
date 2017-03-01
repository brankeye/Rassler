using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.Models.Base;

namespace rassler.backend.domain.Data.Models
{
    [DataContract]
    public class Profile : Entity
    {
        public Profile()
        {
            Payments = new List<Payment>();
        }

        [DataMember]
        public DateTimeOffset StartDate { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(ContactInfoId))]
        public virtual ContactInfo ContactInfo { get; set; }

        [DataMember]
        public long ContactInfoId { get; set; }

        [ForeignKey(nameof(StandingId))]
        public virtual Standing Standing { get; set; }

        [DataMember]
        public long StandingId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [DataMember]
        public long UserId { get; set; }

        [ForeignKey(nameof(SchoolId))]
        public virtual School School { get; set; }

        [DataMember]
        public long SchoolId { get; set; }

        public virtual ICollection<Rank> Ranks { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
