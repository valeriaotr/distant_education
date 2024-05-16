using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Models.Course;
using DistantEducation.Infrastructure.Persistence.Contexts;
using DistantEducation.Infrastructure.Persistence.Entity;
using DistantEducation.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace DistantEducation.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;
    private const int IdLength = 10;

    public CourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CourseModel?> FindCourseById(string? courseId)
    {
        var courseEntity = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
        return courseEntity != null ? EntityMapper.MapCourseEntityToModel(courseEntity) : null;
    }

    public async Task<List<CourseModel>> FindAllCoursesByTariffId(string tariffId)
    {
        List<CourseModel> courses = await _context.Courses.Select(
                t => new CourseModel(t.Id, t.Name, t.AmountOfTasks, t.TariffId)
            ) 
            .ToListAsync(); 
        return courses;
    }

    public async Task<string> AddCourse(CourseModel courseModel)
    {
        var newCourseEntity = new CourseEntity
        {
            Id = Generator.GenerateRandomId(IdLength),
            Name = courseModel.GetName(),
            AmountOfTasks = courseModel.GetAmountOfTasks(),
            TariffId = courseModel.GetTariffId()
        };
        
        _context.Courses.Add(newCourseEntity);
        await _context.SaveChangesAsync();
        return newCourseEntity.Id;
    }

    public async Task UpdateCourseName(CourseModel courseModel)
    {
        var courseEntityToUpdate = ModelMapper.MapCourseModelToEntity(courseModel);
        await _context.Courses.Where(u => u.Id == courseModel.GetId())
            .ExecuteUpdateAsync(b => 
                b.SetProperty(u => u.Name, courseEntityToUpdate.Name));

        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateCourseTasksAmount(CourseModel courseModel)
    {
        var courseEntityToUpdate = ModelMapper.MapCourseModelToEntity(courseModel);
        await _context.Courses.Where(u => u.Id == courseModel.GetId())
            .ExecuteUpdateAsync(b => 
                b.SetProperty(u => u.AmountOfTasks, courseEntityToUpdate.AmountOfTasks));

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCourse(string courseId)
    {
        var course = new CourseEntity { Id = courseId };
        _context.Courses.Attach(course);
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync(); 
    }
}