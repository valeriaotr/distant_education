using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.User.Commands;
using MediatR;

namespace DistantEducation.Application.Events.User.Handlers.CommandHandlers;

public class RegisterNewUserCommandHandler : IRequestHandler<RegisterNewUserCommand, string>
{
    private readonly IUserRepository _userRepository;

    public RegisterNewUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
    {
        var id = await _userRepository.AddUser(request.UserModel);
        return id;
    }
}