using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Course.CreateNewCourse;

public class CreateCourseRequestDto
{
    public string Name { get; set; }
    public int TasksAmount { get; set; }
    public string TariffId { get; set; }

    public CreateCourseRequestDto(string name, int tasksAmount, string tariffId)
    {
        Name = name;
        TasksAmount = tasksAmount;
        TariffId = tariffId;
    }
}