using LuxRide.Application.Features.Commands.User.ViewModels;
using MediatR;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using LuxRide.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.Login
{
    public class CreateAuthTokenCommandHandler : IRequestHandler<CreateAuthTokenCommand, JwtTokenDto>
	{
		private readonly IUserRepository _userRepository;
		private readonly IUserManager _userManager;

		public CreateAuthTokenCommandHandler(IUserRepository userRepository, IUserManager userManager)
		{
			_userRepository = userRepository;
			_userManager = userManager;
		}

		public async Task<JwtTokenDto> Handle(CreateAuthTokenCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetAsync(x=>x.UserName.ToLower() == request.UserName.ToLower());
            if (user.Activated ==false)
            {
				throw new BadRequestException("User Not Activated.");
            }
            if (user == null || user.PasswordHash != PasswordHasher.HashPassword(request.Password) || user.IsDeleted || !user.Activated)
				throw new UnAuthorizedException("Invalid Credensials");

			var randomNum = GenerateRandomNumber();
			var  refreshToken = $"{randomNum}_{user.Id}_{DateTime.UtcNow.AddDays(1)}";
			user.UpdateRefreshToken(refreshToken);
			(string token, DateTime expireDate) = _userManager.GenerateJwtToken(user);
			await _userRepository.Commit();
			return  new JwtTokenDto() { Token = token, RefreshToken= refreshToken, ExpireAt = expireDate};
		}

		private object GenerateRandomNumber()
		{
			var randomNum = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNum);
				return Convert.ToBase64String(randomNum);
			}
		}
	}
}
