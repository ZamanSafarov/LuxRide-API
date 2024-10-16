using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Contact.Create
{
	public class CreateContactCommandValidator:AbstractValidator<CreateContactCommand>
	{
        public CreateContactCommandValidator():base()
        {
			RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name is required.")
			.Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");


			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required.")
				.EmailAddress().WithMessage("A valid email address is required.");

			RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.")
			.Length(2, 100).WithMessage("Subject must be between 2 and 100 characters.");

			RuleFor(x => x.Message)
				.NotEmpty().WithMessage("Message is required.")
			.Length(2, 1000).WithMessage("Subject must be between 2 and 100 characters.");
		}
    }
}
