using System.Runtime.Serialization;
using rassler.backend.domain.Data.DTOs.Base;

namespace rassler.backend.domain.Data.Models.DTOs
{
    [DataContract]
    public class User : Entity
    {
        [DataMember]
        public string Username { get; set; }
    }
}
