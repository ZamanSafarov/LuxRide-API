using FluentValidation;
using LuxRide.Application.Features.Commands.User.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Features.Commands.User.Register
{
	public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
	{
		public RegisterCommandValidator():base() 
		{
			RuleFor(command => command.Name).NotNull();
			RuleFor(command => command.Surname).NotNull();
			RuleFor(command => command.Password).NotNull().MinimumLength(5).WithMessage("Şifrənin uzunluğu minumum 5 olmalıdır.");
			RuleFor(command => command.Email).Must(x=>x.Contains("@gmail.com")).WithMessage("Sadəcə daxili mail olmalıdır!");
		}
	}
}
