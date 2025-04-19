using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Exceptions.HttpProblemDetails.Handler;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Middleware.ExceptionMiddleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logger;
        private readonly ProblemDetailsHandler _problemDetailsHandler;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogService logger)
        {
            _next = next;
            _logger = logger;
            _problemDetailsHandler = new ProblemDetailsHandler();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                _logger.LogInfo($"{DateTime.Now.ToString()} Started");
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing the request.", ex);
                await HandleExceptionAsync(httpContext, ex);
            }
            finally
            {
                _logger.LogInfo($"{DateTime.Now.ToString()} Completed");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            _problemDetailsHandler.Response = context.Response;
            await _problemDetailsHandler.HandleProblemDetailsAsync(exception);
        }
    }

}
