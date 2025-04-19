using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Interfaces.Repositories.TaskCategoryRepositories;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;
using TaskFlow.Persistence.Context;
using TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskCategoryRepository;
using TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskRepository;

namespace TaskFlow.Persistence;

public static class ServiceRegistiration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskDbContext>(opt => { opt.UseInMemoryDatabase("TaskFlowDb"); });

        //services.AddDbContext<TaskDbContext>(opt =>
        //{
        //    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //});

        services.AddScoped<ITaskReadRepository, EfTaskReadRepository>();
        services.AddScoped<ITaskWriteRepository, EfTaskWriteRepository>();

        services.AddScoped<ITaskCategoryReadRepository, EfTaskCategoryReadRepository>();
        services.AddScoped<ITaskCategoryWriteRepository, EfTaskCategoryWriteRepository>();

        return services;
    }
}