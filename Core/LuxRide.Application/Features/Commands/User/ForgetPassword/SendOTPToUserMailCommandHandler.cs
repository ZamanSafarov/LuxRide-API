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
	public class SendOTPToUserMailCommandHandler : IRequestHandler<SendOTPToUserMailCommand, bool>
	{
		private readonly IUserRepository _userRepository;
		private readonly IUserManager _userManager;
		private readonly IEmailManager _emailManager;


		public SendOTPToUserMailCommandHandler(IUserRepository userRepository, IUserManager userManager, IEmailManager emailManager)
		{
			_userRepository = userRepository;
			_userManager = userManager;
			_emailManager = emailManager;
		}

		public async  Task<bool> Handle(SendOTPToUserMailCommand request, CancellationToken cancellationToken)
		{

			var user = await _userRepository.GetAsync(x => x.Email == request.Email);
			if (user == null)
			{
				throw new NotFoundException("User not found.");
			}

			var otp = GenerateOTP();
			user.UpdateOTP(otp.ToString(), DateTime.UtcNow.AddMinutes(3));
			await _emailManager.SendOtpEmailAsync(request.Email, otp.ToString());
			await _userRepository.Update(user);
			await _userRepository.Commit();

			return true;
		}

		public string GenerateOTP()
		{
			Random random = new Random();
			return random.Next(1000, 9999).ToString(); 
		}
	}
}
