﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Application.Exceptions.HttpProblemDetails
{
    public class BusinessProblemDetails : ProblemDetails
    {
        public BusinessProblemDetails(string detail)
        {
            Title = "Business rule violation";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/business";
        }

    }
}
