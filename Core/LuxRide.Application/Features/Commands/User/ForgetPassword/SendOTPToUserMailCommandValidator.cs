using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.ForgetPassword
{
	public class SendOTPToUserMailCommandValidator : AbstractValidator<SendOTPToUserMailCommand>
	{
		public SendOTPToUserMailCommandValidator():base()
		{
			RuleFor(x=>x.Email).NotNull().Must(x => x.Contains("@gmail.com")).WithMessage("Sadəcə daxili mail olmalıdır!");
		}
	}
}
