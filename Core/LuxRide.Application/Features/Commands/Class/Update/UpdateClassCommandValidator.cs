using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Class.Create
{
	internal class UpdateClassCommandValidator : AbstractValidator<UpdateClassCommand>
	{
		public UpdateClassCommandValidator() : base()
		{
			RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");
			RuleFor(x => x.Name)
		.NotEmpty().WithMessage("Name is required.");

		}
	}
}
