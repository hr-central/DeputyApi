using System;
using System.Net;

namespace DeputyApi
{
    public class DeputyApiException : Exception
    {
        public DeputyApiException(HttpStatusCode statusCode, int errorCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }

        public HttpStatusCode StatusCode { get; }
        public int ErrorCode { get; }
    }
}
