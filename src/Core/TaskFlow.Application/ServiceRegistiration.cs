using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TaskFlow.Application;

public static class ServiceRegistiration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}