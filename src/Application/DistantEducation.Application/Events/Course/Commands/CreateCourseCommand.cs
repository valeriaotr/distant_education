using DistantEducation.Application.Models.Course;
using MediatR;

namespace DistantEducation.Application.Events.Course.Commands;

public class CreateCourseCommand : IRequest<string>
{
    public CourseModel CourseModel { get; set; }

    public CreateCourseCommand(CourseModel courseModel)
    {
        CourseModel = courseModel;
    }
}