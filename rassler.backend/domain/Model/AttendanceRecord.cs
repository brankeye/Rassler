using System;
using System.Runtime.Serialization;

namespace rassler.backend.domain.Model
{
    [DataContract]
    public class AttendanceRecord : Entity
    {
        [DataMember]
        public bool IsAttending { get; set; }

        [DataMember]
        public DateTimeOffset Date { get; set; }
        
        public virtual Class Class { get; set; }

        [DataMember]
        public long ClassId { get; set; }
        
        public virtual Profile Profile { get; set; }

        [DataMember]
        public long ProfileId { get; set; }
    }
}
