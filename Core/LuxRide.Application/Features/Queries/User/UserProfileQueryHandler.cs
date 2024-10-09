using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Queries.User.DTOs;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.User
{
	public class UserProfileQueryHandler : IRequestHandler<UserProfileQuery, UserDto>
	{
		private readonly IUserRepository _userRepository;

		public UserProfileQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserDto> Handle(UserProfileQuery request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetAsync(x=>x.Id ==request.Id);
			if (user == null)
				throw new NotFoundException("User Not Found.");


			return new UserDto()
			{
				Email = user.Email,
				Firstname = user.FirstName,
				Lastname = user.LastName,
				Username = user.UserName,

			};
		}
	}
}
