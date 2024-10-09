using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Common.Behaviour
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if (_validators.Any())
			{
				var context = new ValidationContext<TRequest>(request);
				var validaionResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
				var failures = validaionResults.Where(x => x.Errors.Any()).SelectMany(x => x.Errors).ToList();

				if (failures.Any())
				{
					throw new Exceptions.ValidationException(failures);
				}
			}
			return await next();
		}
	}
}
