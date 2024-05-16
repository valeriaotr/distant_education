using DistantEducation.Application.Models.Course;
using DistantEducation.Application.Models.StudyMaterial;

namespace DistantEducation.Application.Contracts.ServicesInterfaces;

public interface ICourseService
{
    Task<CourseModel?> GetCourseAsync(string? courseId);
    Task<string?> GetCourseNameAsync(string? courseId);
    Task<string> CreateCourse(CourseModel courseModel);
    Task UpdateCourseNameAsync(string? courseId, string newName);
    Task<int?> GetTasksAmountAsync(string? courseId);
    Task UpdateTasksAmountAsync(string? courseId, int newTasksAmount);
    Task DeleteCourse(string courseId);
}