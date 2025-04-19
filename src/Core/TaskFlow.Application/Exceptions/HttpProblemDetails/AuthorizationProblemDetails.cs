using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Application.Exceptions.HttpProblemDetails
{
    public class AuthorizationProblemDetails : ProblemDetails
    {
        public AuthorizationProblemDetails(string detail)
        {
            Title = "Authorization error";
            Detail = detail;
            Status = StatusCodes.Status401Unauthorized;
            Type = "https://example.com/probs/authorization";
        }
    }
}
