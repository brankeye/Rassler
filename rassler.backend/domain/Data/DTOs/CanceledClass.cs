using System;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.DTOs.Base;

namespace rassler.backend.domain.Data.Models.DTOs
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
