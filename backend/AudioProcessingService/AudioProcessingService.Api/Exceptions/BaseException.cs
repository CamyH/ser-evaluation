using System.Net;

namespace AudioProcessingService.Api.Exceptions;

public class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
    {
        StatusCode = statusCode;
    }

    public BaseException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.InternalServerError;
    }
}