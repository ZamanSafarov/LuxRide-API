using MediatR;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.User.ViewModels;
using LuxRide.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.User.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, JwtTokenDto>
{
	private readonly IUserManager _userManager;
	private readonly IUserRepository _userRepository;
	public RefreshTokenCommandHandler(IUserManager userManager, IUserRepository userRepository)
	{
		_userManager = userManager;
		_userRepository = userRepository;
	}

	public async Task<JwtTokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
	{
		var refreshToken = request.RefreshToken.Split("_");
		var user = await _userRepository.GetAsync(p => p.RefreshToken == request.RefreshToken);
		if (user == null
			|| !user.Activated
			|| user.IsDeleted)
			throw new UnAuthorizedException("Invalid credentials");

		if (Convert.ToDateTime(refreshToken[2]) < DateTime.UtcNow)
			throw new UnAuthorizedException("token is expiredd");
		(string token, DateTime expire) = _userManager.GenerateJwtToken(user);
		return new JwtTokenDto
		{
			ExpireAt = expire,
			Token = token,
			RefreshToken = request.RefreshToken
		};
	}
}
