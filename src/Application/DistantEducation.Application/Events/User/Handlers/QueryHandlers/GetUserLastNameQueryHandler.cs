using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.User.Queries;
using DistantEducation.Application.Exceptions.User;
using MediatR;

namespace DistantEducation.Application.Events.User.Handlers.QueryHandlers;

public class GetUserLastNameQueryHandler : IRequestHandler<GetUserLastNameQuery, string>
{
    private readonly IUserRepository _userRepository;

    public GetUserLastNameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(GetUserLastNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindUserById(request.UserId);
        if (user == null)
        {
            throw new NullUserException($"User with ID {request.UserId} not found");
        }
        return user.GetLastName() ?? throw new NullUserException($"No user with ID {request.UserId}");
    }
}