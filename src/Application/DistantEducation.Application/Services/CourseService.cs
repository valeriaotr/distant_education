using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Contracts.ServicesInterfaces;
using DistantEducation.Application.Exceptions;
using DistantEducation.Application.Models.Course;
using DistantEducation.Infrastructure.Persistence.Repositories;

namespace DistantEducation.Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<string> CreateCourse(CourseModel courseModel)
    {
        var id = await _courseRepository.AddCourse(courseModel);
        return id;
    }

    public async Task<CourseModel?> GetCourseAsync(string? courseId)
    {
        var course = await _courseRepository.FindCourseById(courseId);

        if (course == null)
        {
            throw new NullCourseException($"Course with ID {courseId} not found.");
        }

        return course;
    }

    public async Task<string?> GetCourseNameAsync(string? courseId)
    {
        var course = await _courseRepository.FindCourseById(courseId);

        if (course == null)
        {
            throw new NullCourseException($"Course with ID {courseId} not found.");
        }

        return course.GetName();
    }

    public async Task UpdateCourseNameAsync(string? courseId, string newName)
    {
        var course = _courseRepository.FindCourseById(courseId).Result;

        if (course == null)
        {
            throw new NullCourseException($"Course with ID {courseId} not found.");
        }

        var newCourse = CourseModel.Builder()
            .Id(courseId)
            .Name(newName)
            .AmountOfTasks(course.GetAmountOfTasks())
            .TariffId(course.GetTariffId())
            .Build();

        await _courseRepository.UpdateCourseName(newCourse);
    }

    public async Task DeleteCourse(string courseId)
    {
        await _courseRepository.DeleteCourse(courseId);
    }

    public async Task<int?> GetTasksAmountAsync(string? courseId)
    {
        var course = await _courseRepository.FindCourseById(courseId);

        if (course == null)
        {
            throw new NullCourseException($"Course with ID {courseId} not found.");
        }
        return course.GetAmountOfTasks();
    }
    
    public async Task UpdateTasksAmountAsync(string? courseId, int newTasksAmount)
    {
        var course = _courseRepository.FindCourseById(courseId).Result;
        if (course == null)
        {
            throw new NullCourseException($"Course with ID {courseId} not found.");
        }
        var newCourse = CourseModel.Builder()
            .Id(courseId)
            .Name(course.GetName())
            .AmountOfTasks(newTasksAmount)
            .TariffId(course.GetTariffId())
            .Build();
        await _courseRepository.UpdateCourseTasksAmount(newCourse);
    }
}