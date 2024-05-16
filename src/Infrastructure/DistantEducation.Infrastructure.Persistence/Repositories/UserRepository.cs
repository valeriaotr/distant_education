using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Models.User;
using DistantEducation.Infrastructure.Persistence.Contexts;
using DistantEducation.Infrastructure.Persistence.Entity;
using DistantEducation.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace DistantEducation.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private const int IdLength = 10;
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserModel?> FindUserById(string userId)
    {
        var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        return EntityMapper.MapUserEntityToModel(userEntity ?? throw new ArgumentNullException($"No user with ID {userId}"));
    }

    public async Task<string> AddUser(UserModel userModel)
    {
        var newUserEntity = new UserEntity
        {
            Id = Generator.GenerateRandomId(IdLength),
            FirstName = userModel.GetFirstName(),
            LastName = userModel.GetLastName(),
            Password = userModel.GetPassword()
        };
        
        await _context.Users.AddAsync(newUserEntity);
        await _context.SaveChangesAsync();
        return newUserEntity.Id;
    }
    
    public async Task UpdateUserName(UserModel userModel)
    {
        var userEntityToUpdate = ModelMapper.MapUserModelToEntity(userModel);
        await _context.Users.Where(u => u.Id == userModel.GetId())
            .ExecuteUpdateAsync(b => 
                b.SetProperty(u => u.FirstName, userEntityToUpdate.FirstName));

        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserLastName(UserModel userModel)
    {
        var userEntityToUpdate = ModelMapper.MapUserModelToEntity(userModel);
        await _context.Users.Where(u => u.Id == userModel.GetId())
            .ExecuteUpdateAsync(b => 
                b.SetProperty(u => u.LastName, userEntityToUpdate.LastName));

        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserPassword(UserModel userModel)
    {
        var userEntityToUpdate = ModelMapper.MapUserModelToEntity(userModel);
        await _context.Users.Where(u => u.Id == userModel.GetId())
            .ExecuteUpdateAsync(b => 
                b.SetProperty(u => u.Password, userEntityToUpdate.Password));

        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteUser(string userId)
    {
        var user = new UserEntity { Id = userId };
        _context.Users.Attach(user);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}