using System;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.DTOs.Base;

namespace rassler.backend.domain.Data.Models.DTOs
{
    [DataContract]
    public class Rank : Entity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public DateTimeOffset AchievementDate { get; set; }

        [DataMember]
        public long ProfileId { get; set; }
    }
}
