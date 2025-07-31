using BrewApi.Data;
using BrewApi.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace BrewApi.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serverVersion = new MariaDbServerVersion(new Version("11.4.7"));
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseMySql(connectionString, serverVersion);
        });
        
        services.AddScoped<IUserRepository, UserRepository>();
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
        
        // services.AddScoped<ITokenService, TokenService>();
        
        return services;
    }
}