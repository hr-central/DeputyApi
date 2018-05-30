using System;

namespace DeputyApi.Authentication
{
    public interface IToken
    {
        string AccessToken { get; }
        string RefreshToken { get; }
        TimeSpan ExpiresIn { get; }
        bool HasExpired();
    }
}
