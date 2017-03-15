using System.Runtime.Serialization;

namespace rassler.backend.domain.DTO
{
    [DataContract]
    public class School : Entity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Website { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
