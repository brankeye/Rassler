using System.Runtime.Serialization;

namespace rassler.backend.domain.DTO
{
    [DataContract]
    public class User : Entity
    {
        [DataMember]
        public string Username { get; set; }
    }
}
