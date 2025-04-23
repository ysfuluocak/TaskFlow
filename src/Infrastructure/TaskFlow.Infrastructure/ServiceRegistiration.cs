using Serilog;
using TaskFlow.Application.Interfaces;
using TaskFlow.Infrastructure.LogService;
using TaskFlow.Infrastructure.FileServices;
using TaskFlow.Infrastructure.Security.Hashing;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Interfaces.Security;

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

            services.AddScoped<IHashingHelper, HashingHelper>();

            return services;
        }
    }
}
