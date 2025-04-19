using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TaskFlow.Application.Interfaces;
using TaskFlow.Infrastructure.FileServices;
using TaskFlow.Infrastructure.LogService;

namespace TaskFlow.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            services.AddSingleton<ILogService, LogManager>();

            return services;
        }
    }
}
