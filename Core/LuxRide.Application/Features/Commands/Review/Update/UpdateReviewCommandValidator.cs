using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Review.Update
{
	public class UpdateReviewCommandValidator:AbstractValidator<UpdateReviewCommand>
	{
		public UpdateReviewCommandValidator() : base()
		{
			RuleFor(x => x.Id).NotEmpty();

			RuleFor(r => r.Name)
			.NotEmpty().WithMessage("Name is required.")
			.MaximumLength(100).WithMessage("Name must be at most 100 characters long.");

			RuleFor(r => r.Position)
				.NotEmpty().WithMessage("Position is required.")
				.MaximumLength(100).WithMessage("Position must be at most 100 characters long.");

			RuleFor(r => r.Rate)
				.InclusiveBetween(0, 5).WithMessage("Rate must be between 0 and 5.");

			RuleFor(r => r.Content)
				.NotEmpty().WithMessage("Content is required.");
		}
	}
}
