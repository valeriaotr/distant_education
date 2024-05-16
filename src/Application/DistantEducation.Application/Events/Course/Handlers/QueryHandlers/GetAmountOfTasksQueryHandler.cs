using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Course.Queries;
using DistantEducation.Application.Exceptions;
using MediatR;

namespace DistantEducation.Application.Events.Course.Handlers.QueryHandlers;

public class GetAmountOfTasksQueryHandler : IRequestHandler<GetAmountOfTasksQuery, int>
{
    private readonly ICourseRepository _courseRepository;
    
    public GetAmountOfTasksQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    public async Task<int> Handle(GetAmountOfTasksQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.FindCourseById(request.CourseId);
        if (course == null)
        {
            throw new NullCourseException($"Course with ID {request.CourseId} not found");
        }
        return course.GetAmountOfTasks();
    }
}