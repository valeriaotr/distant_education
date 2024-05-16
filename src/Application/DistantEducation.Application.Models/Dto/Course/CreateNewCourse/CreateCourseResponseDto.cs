using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Course.CreateNewCourse;

public class CreateCourseResponseDto : ResponseBase
{
    public string? CourseId { get; set; }
    public new HttpStatusCode StatusCode { get; set; }
    public new string Message { get; set; }

    public CreateCourseResponseDto(string courseId, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        CourseId = courseId;
        StatusCode = statusCode;
        Message = message;
    }
}