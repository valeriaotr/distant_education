using MediatR;

namespace DistantEducation.Application.Events.Course.Commands;

public class DeleteCourseCommand : IRequest
{
    public string CourseId { get; set; }
    
    public DeleteCourseCommand(string courseId)
    {
        CourseId = courseId;
    }
}