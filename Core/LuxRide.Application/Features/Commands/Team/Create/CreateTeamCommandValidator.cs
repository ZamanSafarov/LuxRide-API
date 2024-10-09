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
			// Validate Name: Must not be empty and have a length between 2 and 100 characters
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required.")
				.Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

			// Validate Phone: Must not be empty and must follow a specific phone number format
			RuleFor(x => x.Phone)
				.NotEmpty().WithMessage("Phone is required.");
				//.Matches(@"^\+\d{10,15}$").WithMessage("Phone number must be in valid international format.");

			// Validate Email: Must not be empty and must be a valid email address
			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required.")
				.EmailAddress().WithMessage("A valid email address is required.");

			// Validate Photo: Must not be null (or add more rules if required)
			RuleFor(x => x.Photo)
				.NotNull().WithMessage("Photo is required.");

			// Validate Experiences: Must have at least one experience
			RuleFor(x => x.Experiences)
				.NotEmpty().WithMessage("At least one experience is required.");

			// Validate each Experience
			RuleForEach(x => x.Experiences).SetValidator(new ExperienceDtoValidator());
		}
	}

	public class ExperienceDtoValidator : AbstractValidator<ExperienceDto>
	{
		public ExperienceDtoValidator()
		{
			// Validate JobTitle: Must not be empty and have a length between 2 and 100 characters
			RuleFor(x => x.JobTitle)
				.NotEmpty().WithMessage("Job Title is required.")
				.Length(2, 100).WithMessage("Job Title must be between 2 and 100 characters.");

			// Validate JobDescription: Must not be empty
			RuleFor(x => x.JobDescription)
				.NotEmpty().WithMessage("Job Description is required.")
				.Length(2, 500).WithMessage("Job Description must be between 2 and 500 characters.");

			// Validate CompanyName: Must not be empty
			RuleFor(x => x.CompanyName)
				.NotEmpty().WithMessage("Company Name is required.")
				.Length(2, 100).WithMessage("Company Name must be between 2 and 100 characters.");

			// Validate StartDate: Must be a valid date in the past
			RuleFor(x => x.StartDate)
				.LessThanOrEqualTo(DateTime.Now).WithMessage("Start Date must be in the past.");

			// Validate EndDate: If present, must be after StartDate
			RuleFor(x => x.EndDate)
				.GreaterThanOrEqualTo(x => x.StartDate).When(x => x.EndDate.HasValue)
				.WithMessage("End Date must be after the Start Date.");

			// Validate IsPresent: Must be true or false
			RuleFor(x => x.IsPresent)
				.NotNull().WithMessage("IsPresent field is required.");
		}
	}

}
