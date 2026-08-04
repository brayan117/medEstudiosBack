using Application.Interfaces;
using Application.Services;
using Infrastructure.Persistence.MedEstudios;
using Infrastructure.Persistence.MedEstudios.Repositories;
using Infrastructure.Persistence.Salus;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MedEstudiosDbContext>(options =>
            options.UseFirebird(
                configuration.GetConnectionString("FirebirdConnection")));

        services.AddDbContext<SalusDbContext>(options =>
            options.UseFirebird(
                configuration.GetConnectionString("SalusConnection")));

        //servicios de repositorio
        services.AddScoped<IJWTGenerator, JwtGenerator>();

        services.AddScoped<IUsuariosRepository, UsuariosRepository>();

        services.AddScoped<ITiposUsuariosRepository, TiposUsuariosRepository>();

        services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();
        
        services.AddScoped<ITecnicoRespository, TecnicoRepository>();

        //servicios de autenticacion
        services.AddScoped<AuthService>();

        //servicios de negocio
        services.AddScoped<IUsuariosService, UsuariosService>();
        services.AddScoped<IAuditoriaService, AuditoriaService>();

        //servicios de current user
        services.AddScoped<ICurrentUser, CurrentUserService>();
        services.AddHttpContextAccessor();

        return services;
    }
}