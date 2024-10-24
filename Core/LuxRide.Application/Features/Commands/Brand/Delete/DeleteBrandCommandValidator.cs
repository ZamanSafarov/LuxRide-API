using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Brand.Create
{
	public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
	{
		public DeleteBrandCommandValidator() : base()
		{
			RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");

		}
	}
}
