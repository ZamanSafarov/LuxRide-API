using LuxRide.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LuxRide.Application;
using LuxRide.Application.Interfaces;
using Microsoft.AspNetCore.Http;


namespace LuxRide.Persistence.Concretes
{
	public class ClaimManager : IClaimManager
	{
		private readonly IHttpContextAccessor _httpContextAccesor;

		public ClaimManager(IHttpContextAccessor httpContextAccesor)
		{
			_httpContextAccesor = httpContextAccesor;
		}

		public int GetCurrentUserId()
		{
			var claim = GetUserClaims(ClaimTypes.NameIdentifier);

			if (!int.TryParse(claim.Value, out var currentUserId))
				throw new AuthenticationException("Can't Parse this claim Value.");
			return currentUserId;
		}
		public Claim GetUserClaims(string claimType)
		{
			var user = _httpContextAccesor.HttpContext.User;
			if (!user.Identity.IsAuthenticated)
			{
				throw new AuthenticationException("User is not Authenticated.");
			}
			var claim = user.FindFirst(claimType);

			if (claim == null)
			{
				throw new AuthenticationException("User does not have required claim.");

			}
			return claim;
		}
		public IEnumerable<Claim> GetUserClaims(User user)
		{
			return new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
				new Claim(ClaimTypes.Email,user.Email),
				new Claim("FirstName",user.FirstName),
				new Claim("LastName",user.LastName)
			};
		}
	}
}
