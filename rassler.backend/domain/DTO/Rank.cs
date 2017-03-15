using System;
using System.Runtime.Serialization;

namespace rassler.backend.domain.DTO
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
