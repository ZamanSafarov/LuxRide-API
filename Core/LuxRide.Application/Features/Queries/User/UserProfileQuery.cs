using LuxRide.Application.Features.Queries.User.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.User
{
	public class UserProfileQuery:IRequest<UserDto>
	{
		public int Id { get; set; }
	}
}
