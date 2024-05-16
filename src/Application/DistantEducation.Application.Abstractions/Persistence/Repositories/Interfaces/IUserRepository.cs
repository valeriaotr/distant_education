using DistantEducation.Application.Models.User;

namespace DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserModel?> FindUserById(string userId); 
    Task<string> AddUser(UserModel userModel); 
    Task UpdateUserName(UserModel userModel);
    Task UpdateUserLastName(UserModel userModel);
    Task UpdateUserPassword(UserModel userModel);
    Task DeleteUser(string userId); 
}