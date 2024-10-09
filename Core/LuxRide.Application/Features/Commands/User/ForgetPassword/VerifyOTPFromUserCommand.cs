using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.ForgetPassword
{
	public class VerifyOTPFromUserCommand:IRequest<bool>
	{
		public int OTP {  get; set; }
		public string Email {  get; set; }
	}
}
