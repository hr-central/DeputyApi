using System;

namespace DeputyApi.Authentication
{
    public class Token : IToken
    {
        public Token(string accessToken, string refreshToken, DateTime issuedAt, TimeSpan expiresIn)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            IssuedAt = issuedAt;
            ExpiresIn = expiresIn;
        }

        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }
        public DateTime IssuedAt { get; private set; }
        public TimeSpan ExpiresIn { get; private set; }

        public bool HasExpired() => DateTime.UtcNow - IssuedAt.ToUniversalTime() >= ExpiresIn;
    }
}
