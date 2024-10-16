using FluentValidation;
using LuxRide.Application.Features.Commands.Team.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Team.Create
{
	public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
	{
		public CreateTeamCommandValidator()
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

			RuleFor(x => x.Photo)
				.NotNull().WithMessage("Photo is required.");

			RuleFor(x => x.Experiences)
				.NotEmpty().WithMessage("At least one experience is required.");

			RuleForEach(x => x.Experiences).SetValidator(new ExperienceDtoValidator());
		}
	}

	public class ExperienceDtoValidator : AbstractValidator<ExperienceDto>
	{
		public ExperienceDtoValidator()
		{
			RuleFor(x => x.JobTitle)
				.NotEmpty().WithMessage("Job Title is required.")
				.Length(2, 100).WithMessage("Job Title must be between 2 and 100 characters.");

			RuleFor(x => x.JobDescription)
				.NotEmpty().WithMessage("Job Description is required.")
				.Length(2, 500).WithMessage("Job Description must be between 2 and 500 characters.");

			RuleFor(x => x.CompanyName)
				.NotEmpty().WithMessage("Company Name is required.")
				.Length(2, 100).WithMessage("Company Name must be between 2 and 100 characters.");

			RuleFor(x => x.StartDate)
				.LessThanOrEqualTo(DateTime.Now).WithMessage("Start Date must be in the past.");

			RuleFor(x => x.EndDate)
				.GreaterThanOrEqualTo(x => x.StartDate).When(x => x.EndDate.HasValue)
				.WithMessage("End Date must be after the Start Date.");

			RuleFor(x => x.IsPresent)
				.NotNull().WithMessage("IsPresent field is required.");
		}
	}

}
