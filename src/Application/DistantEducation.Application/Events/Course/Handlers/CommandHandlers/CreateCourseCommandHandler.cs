using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Course.Commands;
using MediatR;

namespace DistantEducation.Application.Events.Course.Handlers.CommandHandlers;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, string>
{
    private readonly ICourseRepository _courseRepository;
    public CreateCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    public async Task<string> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        return await _courseRepository.AddCourse(request.CourseModel);
    }
}