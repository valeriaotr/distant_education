using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Course.Commands;
using DistantEducation.Application.Exceptions.User;
using DistantEducation.Application.Models.Course;
using MediatR;

namespace DistantEducation.Application.Events.Course.Handlers.CommandHandlers;

public class UpdateCourseNameCommandHandler : IRequestHandler<UpdateCourseNameCommand>
{
    private readonly ICourseRepository _courseRepository;
    
    public UpdateCourseNameCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task Handle(UpdateCourseNameCommand request, CancellationToken cancellationToken)
    {
        var courseModel = _courseRepository.FindCourseById(request.CourseId).Result;
        if (courseModel == null)
        {
            throw new NullUserException($"User with ID {request.CourseId} not found");
        }
        var newCourseModel = CourseModel.Builder()
            .Id(courseModel.GetId()!)
            .Name(request.NewName)
            .AmountOfTasks(courseModel.GetAmountOfTasks())
            .TariffId(courseModel.GetTariffId())
            .Build();
        await _courseRepository.UpdateCourseName(newCourseModel);
    }
}