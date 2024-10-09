using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.Register
{
	public class VerifyEmailCommand:IRequest<bool>
	{
		public string EmailToken { get; set; }
	}
}
