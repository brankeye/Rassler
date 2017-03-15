using System;
using System.Runtime.Serialization;

namespace rassler.backend.domain.DTO
{
    [DataContract]
    public class AttendanceRecord : Entity
    {
        [DataMember]
        public bool IsAttending { get; set; }

        [DataMember]
        public DateTimeOffset Date { get; set; }

        [DataMember]
        public long ClassId { get; set; }

        [DataMember]
        public long ProfileId { get; set; }
    }
}
