using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Persistence.Repositories;

namespace TaskFlow.Persistence;

public static class ServiceRegistiration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<TaskDbContext>(opt => { opt.UseInMemoryDatabase("TaskFlowDb"); });

        services.AddScoped<ITaskRepository, TaskRepository>();
        return services;
    }
}