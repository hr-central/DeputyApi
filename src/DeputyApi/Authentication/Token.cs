using System;

namespace DeputyApi.Authentication
{
    public class Token : IToken
    {
        public Token(string accessToken, string refreshToken, TimeSpan expiresIn)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
        }

        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }
        public TimeSpan ExpiresIn { get; private set; }
    }
}
