using System.Collections.Generic;
using System.Runtime.Serialization;

namespace rassler.backend.domain.Model
{
    [DataContract]
    public class User : Entity
    {
        public User()
        {
            Profiles = new List<Profile>();
        }
        
        [DataMember]
        public string Username { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
