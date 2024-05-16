using System.Net;

namespace DistantEducation.Application.Models.Dto.BaseResponse;

public class ErrorResponseBase : ResponseBase
{
    public new HttpStatusCode StatusCode { get; set; }
    public new string Message { get; set; }
    
    public ErrorResponseBase(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}