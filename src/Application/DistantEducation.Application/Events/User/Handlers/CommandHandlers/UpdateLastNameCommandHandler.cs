using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.User.Commands;
using DistantEducation.Application.Exceptions.User;
using DistantEducation.Application.Models.User;
using MediatR;

namespace DistantEducation.Application.Events.User.Handlers.CommandHandlers;

public class UpdateLastNameCommandHandler : IRequestHandler<UpdateLastNameCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateLastNameCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UpdateLastNameCommand request, CancellationToken cancellationToken)
    {
        var userModel = _userRepository.FindUserById(request.UserId).Result;
        if (userModel == null)
        {
            throw new NullUserException($"User with ID {request.UserId} not found");
        }
        var newUserModel = UserModel.Builder()
            .Id(userModel.GetId())
            .LastName(request.NewLastName)
            .Build();
        await _userRepository.UpdateUserLastName(newUserModel);
    }
}