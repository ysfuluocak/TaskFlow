using TaskFlow.Application.Exceptions.ExceptionTypes;

namespace TaskFlow.Application.Exceptions.HttpProblemDetails.Handler
{
    public class ProblemDetailsHandler : ProblemDetailsHandlerAbstract
    {
        protected override BusinessProblemDetails HandleDetails(BusinessException businessException)
        {
            return new BusinessProblemDetails(businessException.Message);
        }

        protected override ValidationProblemDetails HandleDetails(ValidationException validationException)
        {
            return new ValidationProblemDetails(validationException.Errors);
        }

        protected override AuthorizationProblemDetails HandleDetails(AuthorizationException authorizationException)
        {
            return new AuthorizationProblemDetails(authorizationException.Message);
        }

        protected override InternalServerErrorProblemDetails HandleDetails(Exception exception)
        {
            return new InternalServerErrorProblemDetails(exception.Message);
        }
    }
}
