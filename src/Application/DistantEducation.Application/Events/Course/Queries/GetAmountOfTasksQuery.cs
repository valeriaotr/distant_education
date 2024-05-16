using MediatR;

namespace DistantEducation.Application.Events.Course.Queries;

public class GetAmountOfTasksQuery : IRequest<int>
{
    public string CourseId { get; set; }
    
    public GetAmountOfTasksQuery(string courseId)
    {
        CourseId = courseId;
    }
}