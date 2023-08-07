﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.CrossCutting.PipelineBehavior
{
    public class ValidationPipelineBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator> _validators;
        private IServiceProvider ServiceProvider { get; }

        public ValidationPipelineBehavior(IEnumerable<IValidator> validators, IServiceProvider serviceProvider)
        {
            _validators = validators;
            ServiceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (failures?.Count != 0)
                throw new ValidationException(failures);

            return await next();
        }
    }
}