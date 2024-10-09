using MediatR;
using LuxRide.Application.Features.Commands.User.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.RefreshToken
{
	public class RefreshTokenCommand : IRequest<JwtTokenDto>
	{
		public string RefreshToken { get; set; }
	}

}
