using DistantEducation.Application.Models.User;
using MediatR;

namespace DistantEducation.Application.Events.User.Commands;

public class RegisterNewUserCommand : IRequest<string>
{
    public UserModel UserModel { get; set; }
    public RegisterNewUserCommand(UserModel userModel)
    {
        UserModel = userModel;
    }
}