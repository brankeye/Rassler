using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.Models.Base;

namespace rassler.backend.domain.Data.Models
{
    [DataContract]
    public class CanceledClass : Entity
    {
        [DataMember]
        public DateTimeOffset Date { get; set; }

        [DataMember]
        public bool IsCanceled { get; set; }

        [ForeignKey(nameof(ClassId))]
        public virtual Class Class { get; set; }

        [DataMember]
        public long ClassId { get; set; }
    }
}
