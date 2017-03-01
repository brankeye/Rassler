using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.Interfaces;

namespace rassler.backend.domain.Data.Models.Base
{
    [DataContract]
    public class Entity : IEntity, IDateInfo
    {
        [Key]
        [DataMember]
        public virtual long Id { get; set; }
        
        [DataMember]
        public DateTimeOffset? DateCreated { get; set; }
        
        [DataMember]
        public DateTimeOffset? DateModified { get; set; }
    }
}
