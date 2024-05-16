using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Course.Queries;
using DistantEducation.Application.Exceptions;
using DistantEducation.Application.Models.Course;
using MediatR;

namespace DistantEducation.Application.Events.Course.Handlers.QueryHandlers;

public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseModel>
{
    private readonly ICourseRepository _courseRepository;
    public GetCourseQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    public async Task<CourseModel> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.FindCourseById(request.CourseId);
        if (course == null)
        {
            throw new NullCourseException($"Course with ID {request.CourseId} not found");
        }
        return course;
    }
}