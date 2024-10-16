using FluentValidation;
using LuxRide.Application.Features.Commands.Team.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Partner.Create
{
	public class CreatePartnerCommandValidator : AbstractValidator<CreatePartnerCommand>
	{
		public CreatePartnerCommandValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required.");

			RuleFor(x => x.Photo)
				.NotNull().WithMessage("Photo is required.");

		}
	}

}
