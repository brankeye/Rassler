using System;
using System.Runtime.Serialization;

namespace rassler.backend.domain.DTO
{
    [DataContract]
    public class Profile : Entity
    {
        [DataMember]
        public DateTimeOffset StartDate { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public long ContactInfoId { get; set; }

        [DataMember]
        public long StandingId { get; set; }

        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public long SchoolId { get; set; }
    }
}
