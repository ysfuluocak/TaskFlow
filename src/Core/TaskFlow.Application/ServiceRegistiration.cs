using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Features.Users.Rules;
using TaskFlow.Application.Features.Boards.Rules;
using TaskFlow.Application.Features.TaskEntities.Rules;

namespace TaskFlow.Application;

public static class ServiceRegistiration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<TaskEntityBusinessRules>();
        services.AddScoped<BoardBusinessRules>();
        services.AddScoped<UserBusinessRules>();


        return services;
    }
}