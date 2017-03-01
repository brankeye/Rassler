using System.Runtime.Serialization;
using rassler.backend.domain.Data.Models.Base;

namespace rassler.backend.domain.Data.Models
{
    [DataContract]
    public class Standing : Entity
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Level { get; set; }
    }
}
