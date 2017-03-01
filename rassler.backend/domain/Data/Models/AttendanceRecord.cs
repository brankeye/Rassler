using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.Models.Base;

namespace rassler.backend.domain.Data.Models
{
    [DataContract]
    public class AttendanceRecord : Entity
    {
        [DataMember]
        public bool IsAttending { get; set; }

        [DataMember]
        public DateTimeOffset Date { get; set; }

        [ForeignKey(nameof(ClassId))]
        public virtual Class Class { get; set; }

        [DataMember]
        public long ClassId { get; set; }

        [ForeignKey(nameof(ProfileId))]
        public virtual Profile Profile { get; set; }

        [DataMember]
        public long ProfileId { get; set; }
    }
}
