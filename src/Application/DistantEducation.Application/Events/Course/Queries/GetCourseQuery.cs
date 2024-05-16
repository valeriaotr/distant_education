using DistantEducation.Application.Models.Course;
using MediatR;

namespace DistantEducation.Application.Events.Course.Queries;

public class GetCourseQuery : IRequest<CourseModel>
{
    public string CourseId { get; set; }
    
    public GetCourseQuery(string courseId)
    {
        CourseId = courseId;
    }
}