using BrewApi.DTO.UserDto;

namespace BrewApi.Repositories.UserRepository;

using BrewApi.DTO;

public interface IUserRepository
{
    public Task<bool> CreateUserAsync(CreateUserDto userDto);
    public bool ValidatePassword(string password, string passwordConfirm);
    public Task<bool> EmailExists(string email);
}