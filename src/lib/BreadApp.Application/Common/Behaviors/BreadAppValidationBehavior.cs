using ErrorOr;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Common.Behaviors
{

    /// <summary>
    /// Validation Behavior for application layer validations
    /// </summary>
    public class BreadAppValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest> _validator;

        public BreadAppValidationBehavior(IValidator<TRequest> validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors.ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));

            return (dynamic)errors;
        }
    }
}
