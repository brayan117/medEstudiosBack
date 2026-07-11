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

        //servicios de repositorio
        services.AddScoped<IJWTGenerator, JwtGenerator>();

        services.AddScoped<IUsuariosRepository, UsuariosRepository>();

        services.AddScoped<ITiposUsuariosRepository, TiposUsuariosRepository>();

        services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();

        //servicios de autenticacion
        services.AddScoped<AuthService>();

        //servicios de negocio
        services.AddScoped<UsuariosService>();
        services.AddScoped<IAuditoriaService, AuditoriaService>();

        //servicios de current user
        services.AddScoped<ICurrentUser, CurrentUserService>();
        services.AddHttpContextAccessor();

        return services;
    }
}