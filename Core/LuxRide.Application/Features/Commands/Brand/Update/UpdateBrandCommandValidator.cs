using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Brand.Create
{
	internal class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
	{
		public UpdateBrandCommandValidator() : base()
		{
			RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");
			RuleFor(x => x.Name)
		.NotEmpty().WithMessage("Name is required.");

		}
	}
}
