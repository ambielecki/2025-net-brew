using System.ComponentModel.DataAnnotations.Schema;

namespace BrewApi.Entities;

public class Brew
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name {  get; set; }

    // Navigation Property
    public Guid UserId  { get; set; }
    public User User { get; set; } = null!;
}