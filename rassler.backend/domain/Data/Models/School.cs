using System.Collections.Generic;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.Models.Base;

namespace rassler.backend.domain.Data.Models
{
    [DataContract]
    public class School : Entity
    {
        public School()
        {
            Members = new List<Profile>();
            Classes = new List<Class>();
        }

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

        public virtual ICollection<Profile> Members { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
