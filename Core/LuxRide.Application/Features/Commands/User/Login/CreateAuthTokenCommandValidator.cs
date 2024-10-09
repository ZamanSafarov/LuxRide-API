using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.Login
{
	public class CreateAuthTokenCommandValidator : AbstractValidator<CreateAuthTokenCommand>
	{
		public CreateAuthTokenCommandValidator():base()
		{
			RuleFor(x => x.UserName).NotNull();
			RuleFor(command => command.Password).NotNull().MinimumLength(5);
		}
	}
}
