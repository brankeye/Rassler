using System.Runtime.Serialization;

namespace rassler.frontend.core.Domain.Objects
{
    [DataContract]
    public class UserContext
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string SchoolName { get; set; }

        [DataMember]
        public bool IsAuthenticated { get; set; }

        [DataMember]
        public Token AccessToken { get; set; }
    }
}
