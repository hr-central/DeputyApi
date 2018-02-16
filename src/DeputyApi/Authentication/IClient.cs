namespace DeputyApi.Authentication
{
    public interface IClient
    {
        string Id { get; }
        string Secret { get; }
        string RedirectUri { get; }
    }
}
