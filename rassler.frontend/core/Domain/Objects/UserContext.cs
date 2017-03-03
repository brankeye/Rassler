namespace rassler.frontend.core.Domain.Objects
{
    public class UserContext
    {
        public string Username { get; set; }

        public string SchoolName { get; set; }

        public bool IsAuthenticated { get; set; }

        public Token AccessToken { get; set; }
    }
}
