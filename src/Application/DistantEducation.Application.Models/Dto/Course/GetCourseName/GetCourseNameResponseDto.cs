using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Course.GetCourseName;

public class GetCourseNameResponseDto: ResponseBase
{
    public string Name { get; set; }
    public new HttpStatusCode StatusCode { get; set; }
    public new string Message { get; set; }

    public GetCourseNameResponseDto(string name, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        Name = name;
        StatusCode = statusCode;
        Message = message;
    }
}