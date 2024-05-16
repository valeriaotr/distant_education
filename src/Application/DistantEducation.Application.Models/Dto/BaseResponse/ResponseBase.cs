using System.Net;

namespace DistantEducation.Application.Models.Dto.BaseResponse;

public abstract class ResponseBase
{
    protected HttpStatusCode StatusCode;
    protected string Message;

    protected ResponseBase(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}