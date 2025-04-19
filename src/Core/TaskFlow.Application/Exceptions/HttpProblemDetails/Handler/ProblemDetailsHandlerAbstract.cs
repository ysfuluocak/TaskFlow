using TaskFlow.Application.Exceptions.ExceptionTypes;

namespace TaskFlow.Application.Exceptions.HttpProblemDetails.Handler
{
    public abstract class ProblemDetailsHandlerAbstract
    {
        public async Task HandleProblemDetailsAsync(Exception exception)
        {
            if (exception is BusinessException businessException)
            {
                await HandleDetails(businessException);
                return;
            }

            if (exception is ValidationException validationException)
            {
                await HandleDetails(validationException);
                return;
            }

            if (exception is AuthorizationException authorizationException)
            {
                await HandleDetails(authorizationException);
                return;
            }

            await HandleDetails(exception);
        }

        protected abstract Task HandleDetails(BusinessException businessException);
        protected abstract Task HandleDetails(ValidationException validationException);
        protected abstract Task HandleDetails(AuthorizationException authorizationException);
        protected abstract Task HandleDetails(Exception exception);
    }
}
