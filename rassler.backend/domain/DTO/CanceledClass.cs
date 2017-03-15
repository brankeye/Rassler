using System;
using System.Runtime.Serialization;

namespace rassler.backend.domain.DTO
{
    [DataContract]
    public class CanceledClass : Entity
    {
        [DataMember]
        public DateTimeOffset Date { get; set; }

        [DataMember]
        public bool IsCanceled { get; set; }

        [DataMember]
        public long ClassId { get; set; }
    }
}
