using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Course.Commands;
using DistantEducation.Application.Exceptions.User;
using DistantEducation.Application.Models.Course;
using MediatR;

namespace DistantEducation.Application.Events.Course.Handlers.CommandHandlers;

public class UpdateAmountOfTasksCommandHandler : IRequestHandler<UpdateAmountOfTasksCommand>
{
    private readonly ICourseRepository _courseRepository;

    public UpdateAmountOfTasksCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task Handle(UpdateAmountOfTasksCommand request, CancellationToken cancellationToken)
    {
        var courseModel = _courseRepository.FindCourseById(request.CourseId).Result;
        if (courseModel == null)
        {
            throw new NullUserException($"User with ID {request.CourseId} not found");
        }
        var newCourseModel = CourseModel.Builder()
            .Id(courseModel.GetId()!)
            .Name(courseModel.GetName())
            .AmountOfTasks(request.NewAmount)
            .TariffId(courseModel.GetTariffId())
            .Build();
        await _courseRepository.UpdateCourseTasksAmount(newCourseModel);
    }
}