using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Course.Commands;
using MediatR;

namespace DistantEducation.Application.Events.Course.Handlers.CommandHandlers;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
{
    private readonly ICourseRepository _courseRepository;

    public DeleteCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        await _courseRepository.DeleteCourse(request.CourseId);
    }
}