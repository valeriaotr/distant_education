namespace DistantEducation.Application.Models.Dto.Course.UpdateAmountOfTasks;

public class UpdateAmountOfTasksRequestDto
{
    public string? CourseId { get; set; }
    public int NewTasksAmount { get; set; }

    public UpdateAmountOfTasksRequestDto(string? courseId, int newTasksAmount)
    {
        CourseId = courseId;
        NewTasksAmount = newTasksAmount;
    }
}