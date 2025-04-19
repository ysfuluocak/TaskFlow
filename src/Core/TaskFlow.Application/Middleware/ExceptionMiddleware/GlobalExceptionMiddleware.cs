using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskFlow.Application.Exceptions.HttpProblemDetails.Handler;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Middleware.ExceptionMiddleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logger;
        private readonly ProblemDetailsHandlerAbstract _problemDetailsHandler;

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
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while processing the request.", ex);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ProblemDetails details = _problemDetailsHandler.HandleProblemDetails(exception);
            context.Response.StatusCode = details.Status ?? StatusCodes.Status500InternalServerError;
            return WriteAsJsonAsync(context.Response, details);
        }

        private Task WriteAsJsonAsync(HttpResponse response, ProblemDetails details)
        {
            response.ContentType = "application/json";
            return JsonSerializer.SerializeAsync(response.Body, details);
        }
    }

}
