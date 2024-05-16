namespace DistantEducation.Application.Models.Dto.Course.UpdateCourseName;

public class UpdateCourseNameRequestDto
{
    public string CourseId { get; set; }
    public string NewCourseName { get; set; }

    public UpdateCourseNameRequestDto(string courseId, string newCourseName)
    {
        CourseId = courseId;
        NewCourseName = newCourseName;
    }
}