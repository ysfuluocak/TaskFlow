using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Exceptions.ExceptionTypes;

namespace TaskFlow.Application.Exceptions.HttpProblemDetails.Handler
{
    public abstract class ProblemDetailsHandlerAbstract
    {
        public ProblemDetails HandleProblemDetails(Exception exception)
        {
            if (exception is BusinessException businessException)
                return HandleDetails(businessException);

            if (exception is ValidationException validationException)
                return HandleDetails(validationException);

            if (exception is AuthorizationException authorizationException)
                return HandleDetails(authorizationException);

            return HandleDetails(exception);
        }

        protected abstract ProblemDetails HandleDetails(BusinessException businessException);
        protected abstract ProblemDetails HandleDetails(ValidationException validationException);
        protected abstract ProblemDetails HandleDetails(AuthorizationException authorizationException);
        protected abstract ProblemDetails HandleDetails(Exception exception);
    }
}
