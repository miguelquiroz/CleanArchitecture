using System.Net;

namespace CleanArchitecture.Domain.Exceptions
{
    public class CustomValidationException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public CustomValidationException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest
        ) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
