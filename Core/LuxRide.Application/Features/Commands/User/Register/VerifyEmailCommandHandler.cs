using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.Register
{
	public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, bool>
	{
		private readonly IUserRepository _userRepository;

		public VerifyEmailCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<bool> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
		{
			var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(request.EmailToken));
			var email = decodedToken.Split(':')[0];
			var user = await _userRepository.GetAsync(x=>x.Email == email);
			if (user == null)
				throw new NotFoundException("User Not Found.");
			if (user.Activated == true)
				throw new UserAlreadyActivatedException("User already Activated.");

			user.ActivateUser(true);
			await _userRepository.Update(user);
			await _userRepository.Commit();
			return true;
		}
	}
}
