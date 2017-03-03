using System.Runtime.Serialization;
using rassler.backend.domain.Data.DTOs.Base;

namespace rassler.backend.domain.Data.Models.DTOs
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
