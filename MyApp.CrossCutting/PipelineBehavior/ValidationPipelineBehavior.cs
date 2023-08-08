using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.CrossCutting.PipelineBehavior
{
    public class ValidationPipelineBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private IServiceProvider ServiceProvider { get; }

        public ValidationPipelineBehavior(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validator = ServiceProvider
                .GetService<IValidator<TRequest>>();

            var failures = (
                validator != default ?
                    await validator.ValidateAsync(request, cancellationToken) :
                    default
                )
                ?.Errors;

            var errorsDictionary = failures?.Where(x => x != null)
                .GroupBy(
                        x => x.PropertyName,
                        x => x.ErrorMessage,
                        (propertyName, errorMessages) => new
                        {
                            Key = propertyName,
                            Values = errorMessages.Distinct().ToArray()
                        })
                .ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary?.Count>0)
                throw new ValidationException(failures);

            return await next();
        }
    }
}