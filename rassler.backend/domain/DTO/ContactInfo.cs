using System.Runtime.Serialization;

namespace rassler.backend.domain.DTO
{
    [DataContract]
    public class ContactInfo : Entity
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
