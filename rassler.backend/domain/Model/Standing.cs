using System.Runtime.Serialization;

namespace rassler.backend.domain.Model
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
