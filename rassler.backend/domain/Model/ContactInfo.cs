using System.Runtime.Serialization;

namespace rassler.backend.domain.Model
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
        
        public virtual Profile Profile { get; set; }

        [DataMember]
        public long ProfileId { get; set; }
    }
}
