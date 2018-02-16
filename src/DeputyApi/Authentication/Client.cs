namespace DeputyApi.Authentication
{
    public class Client : IClient
    {
        public Client(string id, string secret, string redirectUri)
        {
            Id = id;
            Secret = secret;
            RedirectUri = redirectUri;
        }

        public string Id { get; private set; }
        public string Secret { get; private set; }
        public string RedirectUri { get; private set; }
    }
}
