using System.Runtime.Serialization;
using rassler.backend.domain.Data.Interfaces;

namespace rassler.backend.domain.Data.DTOs.Base
{

    [DataContract]
    public class Entity : IEntity
    {
        [DataMember]
        public virtual long Id { get; set; }
    }
}
