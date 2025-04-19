using FluentValidation;
using MediatR;
using TaskFlow.Application.Exceptions.ExceptionTypes;
using ValidationException = TaskFlow.Application.Exceptions.ExceptionTypes.ValidationException;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null);

            if (failures.Any())
                throw new ValidationException(failures.DistinctBy(f => f.PropertyName).Select(f => new ValidationExceptionModel(f.PropertyName, f.ErrorMessage)));
        }

        return await next();
    }
}
