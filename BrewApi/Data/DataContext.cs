using BrewApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrewApi.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Brew> Brews { get; set; }
}