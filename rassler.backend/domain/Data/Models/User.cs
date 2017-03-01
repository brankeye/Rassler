using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using rassler.backend.domain.Data.Models.Base;

namespace rassler.backend.domain.Data.Models
{
    [DataContract]
    public class User : Entity
    {
        public User()
        {
            Profiles = new List<Profile>();
        }

        [Index]
        [DataMember]
        public string Username { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
