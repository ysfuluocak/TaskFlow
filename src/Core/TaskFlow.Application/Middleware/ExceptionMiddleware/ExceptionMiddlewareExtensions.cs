using Microsoft.AspNetCore.Builder;

namespace TaskFlow.Application.Middleware.ExceptionMiddleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
