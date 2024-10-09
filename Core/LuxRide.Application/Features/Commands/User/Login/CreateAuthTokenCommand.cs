using LuxRide.Application.Features.Commands.User.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.Login
{
	public class CreateAuthTokenCommand:IRequest<JwtTokenDto>
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
