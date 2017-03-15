using System;
using System.Runtime.Serialization;

namespace rassler.backend.domain.DTO
{
    [DataContract]
    public class Payment : Entity
    {
        [DataMember]
        public double Amount { get; set; }

        [DataMember]
        public DateTimeOffset StartDate { get; set; }

        [DataMember]
        public DateTimeOffset EndDate { get; set; }

        [DataMember]
        public long ProfileId { get; set; }
    }
}
