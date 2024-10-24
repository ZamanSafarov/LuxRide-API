using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Class.Create
{
	public class DeleteClassCommandValidator : AbstractValidator<DeleteClassCommand>
	{
		public DeleteClassCommandValidator() : base()
		{
			RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");

		}
	}
}
