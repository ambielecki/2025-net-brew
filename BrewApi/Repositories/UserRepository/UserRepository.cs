using System.Security.Cryptography;
using System.Text;
using BrewApi.Data;
using BrewApi.DTO.UserDto;
using BrewApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrewApi.Repositories.UserRepository;

public class UserRepository(DataContext context): IUserRepository
{
    public async Task<bool> CreateUserAsync(CreateUserDto userDto)
    {
        using var hmac = new HMACSHA512();
        
        var user = new User {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
            PasswordSalt = hmac.Key
        };
        
        context.Users.Add(user);
        var result = await context.SaveChangesAsync();

        return result > 0;
    }
    
    public bool ValidatePassword(string password, string passwordConfirm)
    {
        return password == passwordConfirm;
    }

    public async Task<bool> EmailExists(string email)
    {
        return await context.Users.AnyAsync(user => user.Email.ToLower() == email.ToLower());
    }
}