using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Faq.Create
{
	internal class UpdateFaqCommandValidator : AbstractValidator<UpdateFaqCommand>
	{
		public UpdateFaqCommandValidator() : base()
		{
			RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");
			RuleFor(x => x.Question)
		.NotEmpty().WithMessage("Question is required.");

			RuleFor(x => x.Answer)
			.NotEmpty().WithMessage("Answer is required.");
		}
	}
}
