using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.User.Queries;
using DistantEducation.Application.Exceptions.User;
using DistantEducation.Application.Models.User;
using MediatR;

namespace DistantEducation.Application.Events.User.Handlers.QueryHandlers;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindUserById(request.UserId);
        if (user == null)
        {
            throw new NullUserException($"User with ID {request.UserId} not found");
        }
        return user;
    }
}