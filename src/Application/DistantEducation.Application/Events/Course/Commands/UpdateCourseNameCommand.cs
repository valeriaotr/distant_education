using MediatR;

namespace DistantEducation.Application.Events.Course.Commands;

public class UpdateCourseNameCommand : IRequest
{
    public string CourseId { get; set; }
    public string NewName { get; set; }

    public UpdateCourseNameCommand(string courseId, string newName)
    {
        CourseId = courseId;
        NewName = newName;
    }
}