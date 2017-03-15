using System.Collections.Generic;
using System.Runtime.Serialization;

namespace rassler.backend.domain.Model
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

        public virtual Profile Owner { get; set; }

        public long OwnerId { get; set; }

        public virtual ICollection<Profile> Members { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
