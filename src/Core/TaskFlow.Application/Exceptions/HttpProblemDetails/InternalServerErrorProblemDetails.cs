﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Application.Exceptions.HttpProblemDetails
{
    public class InternalServerErrorProblemDetails : ProblemDetails
    {
        public InternalServerErrorProblemDetails(string detail)
        {
            Title = "Internal server error";
            Detail = detail;
            Status = StatusCodes.Status500InternalServerError;
            Type = "https://example.com/probs/internal";
        }
    }
}
