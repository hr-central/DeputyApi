namespace DeputyApi
{
    public class DeputyOptions
    {
        public DeputyOptions(string subdomain, string region, string apiVersion)
        {
            Subdomain = subdomain;
            Region = region;
            ApiVersion = apiVersion;
        }

        public string Subdomain { get; private set; }
        public string Region { get; private set; }
        public string ApiVersion { get; private set; }
    }
}
