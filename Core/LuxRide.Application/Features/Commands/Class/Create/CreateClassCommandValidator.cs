using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Class.Create
{
	public class CreateClassCommandValidator:AbstractValidator<CreateClassCommand>
	{
        public CreateClassCommandValidator():base()
        {
			RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name is required.");
		}
    }
}
