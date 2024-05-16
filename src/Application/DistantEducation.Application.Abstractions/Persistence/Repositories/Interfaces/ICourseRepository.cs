using DistantEducation.Application.Models.Course;

namespace DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;

public interface ICourseRepository
{
    Task<List<CourseModel>> FindAllCoursesByTariffId(string tariffId);
    Task<CourseModel?> FindCourseById(string? courseId);
    Task<string> AddCourse(CourseModel courseModel);
    Task UpdateCourseTasksAmount(CourseModel courseModel);
    Task UpdateCourseName(CourseModel courseModel);
    Task DeleteCourse(string courseId);
}