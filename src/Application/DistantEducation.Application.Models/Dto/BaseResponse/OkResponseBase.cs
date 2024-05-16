using System.Net;

namespace DistantEducation.Application.Models.Dto.BaseResponse;

public class OkResponseBase : ResponseBase
{
    public OkResponseBase(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}