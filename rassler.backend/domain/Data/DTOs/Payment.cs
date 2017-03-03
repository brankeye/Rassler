using System;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.DTOs.Base;

namespace rassler.backend.domain.Data.Models.DTOs
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
