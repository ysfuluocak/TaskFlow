﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Application.Exceptions.HttpProblemDetails
{
    public class NotFoundProblemDetails : ProblemDetails
    {
        public NotFoundProblemDetails(string detail)
        {
            Title = "Not found";
            Detail = detail;
            Status = StatusCodes.Status404NotFound;
            Type = "https://example.com/probs/notfound";
        }
    }
}
