using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskFlow.Application.Exceptions.ExceptionTypes;

namespace TaskFlow.Application.Exceptions.HttpProblemDetails.Handler
{
    public class ProblemDetailsHandler : ProblemDetailsHandlerAbstract
    {
        private HttpResponse _response;

        public HttpResponse Response
        {
            get { return _response ?? throw new ArgumentNullException(nameof(_response)); }
            set { _response = value; }
        }
        protected override async Task HandleDetails(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            var details = new BusinessProblemDetails(businessException.Message);
            await WriteAsJsonAsync(Response, details);
        }

        protected override async Task HandleDetails(ValidationException validationException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            var details = new ValidationProblemDetails(validationException.Errors);
            await WriteAsJsonAsync(Response, details);
        }

        protected override async Task HandleDetails(AuthorizationException authorizationException)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            var details = new AuthorizationProblemDetails(authorizationException.Message);
            await WriteAsJsonAsync(Response, details);
        }

        protected override async Task HandleDetails(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            var details = new InternalServerErrorProblemDetails(exception.Message);
            await WriteAsJsonAsync(Response, details);
        }

        private static async Task WriteAsJsonAsync<T>(HttpResponse response, T details)
            where T : ProblemDetails
        {
            response.ContentType = "application/json";
            await JsonSerializer.SerializeAsync(response.Body, details);
        }
    }
}
