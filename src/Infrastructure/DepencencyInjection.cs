using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.context;

namespace Infrastructure;

public static class DepencencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<FirebirdDbContext>();
        return services;
    }
}