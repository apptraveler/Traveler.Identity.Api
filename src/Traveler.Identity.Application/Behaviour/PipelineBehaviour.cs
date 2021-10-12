using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Traveler.Identity.Domain.Exceptions;

namespace Traveler.Identity.Application.Behaviour
{
    public class PipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly IMediator _bus;

        public PipelineBehaviour(IEnumerable<IValidator<TRequest>> validators, IMediator bus)
        {
            _validators = validators;
            _bus = bus;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!ValidateRequest(request))
            {
                return default;
            }

            return await next();
        }

        private bool ValidateRequest(TRequest request)
        {
            var failures = _validators
                .Select(v => v.Validate((IValidationContext)request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (!failures.Any()) return true;
            
            foreach (var error in failures)
            {
                _bus.Publish(new ExceptionNotification(error.ErrorCode, error.ErrorMessage, error.PropertyName));
            }

            return false;
        }
    }
}