using MediatR;

namespace DistantEducation.Application.Events.Course.Queries;

public class GetCourseNameQuery: IRequest<string>
{
    public string CourseId { get; set; }
    
    public GetCourseNameQuery(string courseId)
    {
        CourseId = courseId;
    }
}