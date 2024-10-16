using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Faq.Create
{
	public class DeleteFaqCommandValidator : AbstractValidator<DeleteFaqCommand>
	{
		public DeleteFaqCommandValidator() : base()
		{
			RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");

		}
	}
}
