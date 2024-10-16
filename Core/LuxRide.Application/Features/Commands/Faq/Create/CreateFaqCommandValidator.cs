using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Faq.Create
{
	public class CreateFaqCommandValidator:AbstractValidator<CreateFaqCommand>
	{
        public CreateFaqCommandValidator():base()
        {
			RuleFor(x => x.Question)
			.NotEmpty().WithMessage("Question is required.");

			RuleFor(x => x.Answer)
			.NotEmpty().WithMessage("Answer is required.");
		}
    }
}
