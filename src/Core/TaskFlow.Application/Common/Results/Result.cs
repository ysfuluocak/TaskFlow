﻿
namespace TaskFlow.Application.Common.Results
{
    public class Result<T>
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public T Data { get; set; }

        public static Result<T> Success(T data) =>
            new Result<T> { Succeeded = true, Data = data };

        public static Result<T> Failure(params string[] errors) =>
            new Result<T> { Succeeded = false, Errors = errors };
    }

}
