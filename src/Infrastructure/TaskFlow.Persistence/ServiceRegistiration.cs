using TaskFlow.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Interfaces.Repositories.UserRepositories;
using TaskFlow.Application.Interfaces.Repositories.BoardRepositories;
using TaskFlow.Application.Interfaces.Repositories.CommentRepositories;
using TaskFlow.Application.Interfaces.Repositories.BoardStepRepositories;
using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;
using TaskFlow.Application.Interfaces.Repositories.AttachmentRepositories;
using TaskFlow.Persistence.Repositories.EfCoreRepositories.UserRepositories;
using TaskFlow.Persistence.Repositories.EfCoreRepositories.BoardRepositories;
using TaskFlow.Persistence.Repositories.EfCoreRepositories.CommentRepositories;
using TaskFlow.Persistence.Repositories.EfCoreRepositories.BoardStepRepositories;
using TaskFlow.Persistence.Repositories.EfCoreRepositories.AttachmentRepositories;
using TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskEntityRepositories;

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

        services.AddScoped<ITaskEntityReadRepository, EfTaskEntityReadRepository>();
        services.AddScoped<ITaskEntityWriteRepository, EfTaskEntityWriteRepository>();

        services.AddScoped<IBoardReadRepository, EfBoardReadRepository>();
        services.AddScoped<IBoardWriteRepository, EfBoardWriteRepository>();

        services.AddScoped<IBoardStepReadRepository, EfBoardStepReadRepository>();
        services.AddScoped<IBoardStepWriteRepository, EfBoardStepWriteRepository>();

        services.AddScoped<IAttachmentReadRepository, EfAttachmentReadRepository>();
        services.AddScoped<IAttachmentWriteRepository, EfAttachmentWriteRepository>();

        services.AddScoped<ICommentReadRepository, EfCommentReadRepository>();
        services.AddScoped<ICommentWriteRepository, EfCommentWriteRepository>();

        services.AddScoped<IUserReadRepository, EfUserReadRepository>();
        services.AddScoped<IUserWriteRepository, EfUserWriteRepository>();

        return services;
    }
}