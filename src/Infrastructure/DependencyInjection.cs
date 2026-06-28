using Application.Interfaces;
using Application.Services;
using Infrastructure.Persistence.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseFirebird(
                configuration.GetConnectionString("FirebirdConnection")));

        services.AddScoped<IJWTGenerator, JwtGenerator>();

        services.AddScoped<IUsuariosRepository, UsuariosRepository>();

        services.AddScoped<ITiposUsuariosRepository, TiposUsuariosRepository>();

        services.AddScoped<AuthService>();

        return services;
    }
}