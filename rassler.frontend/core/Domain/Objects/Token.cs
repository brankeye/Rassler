using System.Runtime.Serialization;

namespace rassler.frontend.core.Domain.Objects
{
    [DataContract]
    public class Token
    {
        [DataMember]
        public string Access_Token { get; set; }

        [DataMember]
        public int Expires_In { get; set; }

        [DataMember]
        public string Token_Type { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
