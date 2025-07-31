using BrewApi.DTO.UserDto;
using BrewApi.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace BrewApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterController(IUserRepository userRepository): ControllerBase
{
    [HttpPost()]
    public async Task<ActionResult> Register(CreateUserDto userDto)
    {
        if (!userRepository.ValidatePassword(userDto.Password, userDto.PasswordConfirm))
        {
            return BadRequest("Password doesn't match");
        }

        if (await userRepository.EmailExists(userDto.Email))
        {
            return BadRequest("Email already exists");
        }

        if (await userRepository.CreateUserAsync(userDto) == false)
        {
            return BadRequest("Something went wrong");
        }
        
        return Ok();
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Test");
    }
}