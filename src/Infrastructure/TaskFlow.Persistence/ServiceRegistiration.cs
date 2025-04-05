using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;
using TaskFlow.Persistence.Context;
using TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskRepository;

namespace TaskFlow.Persistence;

public static class ServiceRegistiration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<TaskDbContext>(opt => { opt.UseInMemoryDatabase("TaskFlowDb"); });

        services.AddScoped<ITaskReadRepository, EfTaskReadRepository>();
        services.AddScoped<ITaskWriteRepository, EfTaskWriteRepository>();
        return services;
    }
}