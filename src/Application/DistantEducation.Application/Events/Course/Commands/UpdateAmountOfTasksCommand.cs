using MediatR;

namespace DistantEducation.Application.Events.Course.Commands;

public class UpdateAmountOfTasksCommand : IRequest
{
    public string? CourseId { get; set; }
    public int NewAmount { get; set; }

    public UpdateAmountOfTasksCommand(string? courseId, int newAmount)
    {
        CourseId = courseId;
        NewAmount = newAmount;
    }
}