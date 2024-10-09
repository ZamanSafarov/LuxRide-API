using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.Concretes
{
	public class UserManager : IUserManager
	{
		private readonly IClaimManager _claimManager;
		private readonly IConfiguration _configuration;

		public UserManager(IClaimManager claimManager, IConfiguration configuration)
		{
			_claimManager = claimManager;
			_configuration = configuration;
		}

		public (string token, DateTime expireAt) GenerateJwtToken(User user)
		{
			var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) };
			claims.AddRange(_claimManager.GetUserClaims(user));

			var jwtSettings = _configuration.GetSection("JWT");
			var key = jwtSettings["SecretKey"];
			SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
			var expireDate = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpireAt"]));
			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
				signingCredentials: signingCredentials,
				claims: claims,
				expires: expireDate
				);
			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			return (jwtSecurityTokenHandler.WriteToken(jwtSecurityToken), expireDate);
		}

		public int GetCurrentUserId()
		{
			return _claimManager.GetCurrentUserId();
		}
	}
}
