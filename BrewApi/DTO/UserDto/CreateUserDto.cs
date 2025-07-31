using System.ComponentModel.DataAnnotations;

namespace BrewApi.DTO.UserDto;

public class CreateUserDto
{
    [Required]
    public required string FirstName { get; set; }
    
    [Required]
    public required string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string PasswordConfirm { get; set; }
}