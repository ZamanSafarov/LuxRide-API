using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.ForgetPassword
{
	public class ResetUserPasswordCommandValidator : AbstractValidator<ResetUserPasswordCommand>
	{
		public ResetUserPasswordCommandValidator():base()
		{
			RuleFor(x=>x.NewPassword).NotNull().MinimumLength(5);
			RuleFor(x => x.Email).NotNull();
		}
	}
}
