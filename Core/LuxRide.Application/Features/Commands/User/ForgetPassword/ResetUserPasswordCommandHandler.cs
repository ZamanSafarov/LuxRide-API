using MediatR;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using LuxRide.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.ForgetPassword
{
	public class ResetUserPasswordCommandHandler : IRequestHandler<ResetUserPasswordCommand, bool>
	{
		private readonly IUserRepository _userRepository;
		private readonly IUserManager _userManager;
		public ResetUserPasswordCommandHandler(IUserRepository userRepository, IUserManager userManager)
		{
			_userRepository = userRepository;
			_userManager = userManager;
		}

		
		public async Task<bool> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetAsync(x => x.Email == request.Email);
			if (user == null)
			{
				throw new NotFoundException("User not found.");
			}

			user.ResetPassword(PasswordHasher.HashPassword(request.NewPassword));
			await _userRepository.Update(user);
			await _userRepository.Commit();
			return true;
		}
	}
}
