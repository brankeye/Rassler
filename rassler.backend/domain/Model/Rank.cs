using System;
using System.Runtime.Serialization;

namespace rassler.backend.domain.Model
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
        
        public virtual Profile Profile { get; set; }

        [DataMember]
        public long ProfileId { get; set; }
    }
}
