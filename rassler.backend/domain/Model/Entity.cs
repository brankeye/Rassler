using System;
using System.Runtime.Serialization;
using rassler.backend.domain.Model.Interfaces;

namespace rassler.backend.domain.Model
{
    [DataContract]
    public class Entity : IEntity, IDateInfo
    {
        [DataMember]
        public virtual long Id { get; set; }
        
        [DataMember]
        public DateTimeOffset? DateCreated { get; set; }
        
        [DataMember]
        public DateTimeOffset? DateModified { get; set; }
    }
}
