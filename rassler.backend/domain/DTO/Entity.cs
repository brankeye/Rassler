using System.Runtime.Serialization;
using rassler.backend.domain.Model.Interfaces;

namespace rassler.backend.domain.DTO
{
    [DataContract]
    public class Entity : IEntity
    {
        [DataMember]
        public virtual long Id { get; set; }
    }
}
