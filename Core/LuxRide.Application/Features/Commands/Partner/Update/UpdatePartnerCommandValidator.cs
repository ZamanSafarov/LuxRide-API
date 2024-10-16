using FluentValidation;
using LuxRide.Application.Features.Commands.Partner.Update;
using LuxRide.Application.Features.Commands.Team.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Partner.Update
{


	public class UpdatePartnerCommandValidator : AbstractValidator<UpdatePartnerCommand>
	{
		public UpdatePartnerCommandValidator()
		{
			RuleFor(x => x.Id).NotNull();

			RuleFor(x => x.Name)
					.NotEmpty().WithMessage("Name is required.");

			RuleFor(x => x.Photo)
				.NotNull().WithMessage("Photo is required.");
		}
	}
}
