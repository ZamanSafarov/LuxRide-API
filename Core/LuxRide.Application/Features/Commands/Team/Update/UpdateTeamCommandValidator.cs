using FluentValidation;
using LuxRide.Application.Features.Commands.Team.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Team.Update
{


	public class UpdateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
	{
		public UpdateTeamCommandValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required.")
				.Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

			RuleFor(x => x.Phone)
				.NotEmpty().WithMessage("Phone is required.")
				.Matches(@"^\+\d{10,15}$").WithMessage("Phone number must be in valid international format.");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required.")
				.EmailAddress().WithMessage("A valid email address is required.");
			

			RuleFor(x => x.Experiences)
				.NotEmpty().WithMessage("At least one experience is required.");

			RuleForEach(x => x.Experiences).SetValidator(new ExperienceDtoValidator());
		}
	}
}
