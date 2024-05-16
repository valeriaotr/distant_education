using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Course.Queries;
using DistantEducation.Application.Exceptions;
using MediatR;

namespace DistantEducation.Application.Events.Course.Handlers.QueryHandlers;

public class GetCourseNameQueryHandler : IRequestHandler<GetCourseNameQuery, string?>
{
    private readonly ICourseRepository _courseRepository;
    
    public GetCourseNameQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<string?> Handle(GetCourseNameQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.FindCourseById(request.CourseId);
        if (course == null)
        {
            throw new NullCourseException($"Course with ID {request.CourseId} not found");
        }
        return course.GetName();
    }
}