using MediatR;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.Register
{
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
	{
		private readonly IUserRepository _userRepository;
		private readonly IEmailManager _emailManager;

		public RegisterCommandHandler(IUserRepository userRepository, IEmailManager emailManager)
		{
			_userRepository = userRepository;
			_emailManager = emailManager;
		}

		public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
		{
			var exsistUser = await _userRepository.GetAsync(x=>x.UserName.ToLower() == request.UserName.ToLower());
			if (exsistUser is not null)
				throw new UniqueException("UserName must be Unique.");
			var user = new Domain.Entities.User();
			user.SetDetails(request.Name,request.Surname,request.UserName,request.Email,request.Password);

			var emailToken = GenerateEmailToken(user.Email);

			var verificationUrl = $"https://luxride.com/verify-email?token={emailToken}";

			await _emailManager.SendVerificationEmail(user.Email, verificationUrl);

			await _userRepository.AddAsync(user);
			await _userRepository.Commit();

		
			return true;
		}
		private string GenerateEmailToken(string email)
		{
			// Use a combination of the user's email and current time for token generation
			return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{email}:{Guid.NewGuid()}"));
		}
	}
}
