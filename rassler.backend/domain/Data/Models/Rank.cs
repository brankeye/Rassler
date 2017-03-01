using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.Models.Base;

namespace rassler.backend.domain.Data.Models
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

        [ForeignKey(nameof(ProfileId))]
        public virtual Profile Profile { get; set; }

        [DataMember]
        public long ProfileId { get; set; }
    }
}
