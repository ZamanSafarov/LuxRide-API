using MediatR;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.ForgetPassword
{
	public class VerifyOTPFromUserCommandHandler : IRequestHandler<VerifyOTPFromUserCommand, bool>
	{
		private readonly IUserRepository _userRepository;
		private readonly IUserManager _userManager;

		public VerifyOTPFromUserCommandHandler(IUserRepository userRepository, IUserManager userManager)
		{
			_userRepository = userRepository;
			_userManager = userManager;
		}

		public async Task<bool> Handle(VerifyOTPFromUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetAsync(x => x.Email == request.Email);
			if (user == null)
			{
				throw new NotFoundException("User not found.");
			}
			if (user.OTPExpireAt <DateTime.UtcNow)
			{
				throw new BadRequestException("OTP Expired.");
			}
			return true;
		}
	}
}
