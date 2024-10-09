using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.Register
{
	public class VerifyEmailCommandValidator:AbstractValidator<VerifyEmailCommand>
	{
		public VerifyEmailCommandValidator():base()
		{
			RuleFor(command => command.EmailToken).NotNull();
		}
	}
}
