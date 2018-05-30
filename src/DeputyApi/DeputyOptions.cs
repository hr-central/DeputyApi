namespace DeputyApi
{
    public class DeputyOptions
    {
        public DeputyOptions(string endpoint, string apiVersion)
        {
            Endpoint = endpoint;
            ApiVersion = apiVersion;
        }

        public string Endpoint { get; private set; }
        public string ApiVersion { get; private set; }
    }
}
