using FluentValidation;
using LuxRide.Application.Features.Commands.About.Update;
using LuxRide.Application.Features.Commands.Team.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.About.Update
{


	public class UpdateAboutCommandValidator : AbstractValidator<UpdateAboutCommand>
	{
		public UpdateAboutCommandValidator()
		{
			RuleFor(x => x.Id).NotNull();

			RuleFor(x => x.Description)
					.NotEmpty().WithMessage("Description is required.");

			RuleFor(x => x.Title)
				.NotEmpty().WithMessage("Title is required.");

			RuleFor(x => x.Photo)
				.NotNull().WithMessage("Photo is required.");
		}
	}
}
