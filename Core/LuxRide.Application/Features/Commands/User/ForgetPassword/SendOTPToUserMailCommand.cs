using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.ForgetPassword
{
	public class SendOTPToUserMailCommand:IRequest<bool>
	{
		public string Email { get; set; }
	}
}
