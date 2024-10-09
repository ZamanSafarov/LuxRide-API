using LuxRide.Domain.Common;
using LuxRide.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LuxRide.Domain.Entities
{
	public class User: IBaseEntity
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string UserName { get; private set; }
		public string Email { get; private set; }
		public string PasswordHash { get; private set; }
		public DateTime LastPasswordChangeDateTime { get; private set; }
		public string? RefreshToken { get; private set; }
		public string? OTP { get; private set; }
		public DateTime? OTPExpireAt { get; private set; }
		public bool IsDeleted { get; private set; }
		public bool Activated { get; private set; }
		public int Id { get; set; }

		public void SetDetails(string firstName, string lastName, string userName, string email, string password)
		{
			FirstName = firstName;
			LastName = lastName;
			UserName = userName;
			Email = email;
			IsDeleted = false;
			PasswordHash = PasswordHasher.HashPassword(password);
		}
		public void ActivateUser(bool access)
		{ 
			Activated = access; 
		}
		public void SetProfile(string firstName, string lastName, string userName)
		{
			FirstName = firstName;
			LastName = lastName;
			UserName = userName;
		}
		public void SetPasswordHash(string newPasswordHash)
		{
			if (PasswordHash != newPasswordHash)
			{
				PasswordHash = newPasswordHash;
				LastPasswordChangeDateTime = DateTime.UtcNow.AddHours(4);
			}
		}
		public void ResetPassword(string newPasswordHash)
		{
			PasswordHash = newPasswordHash;
			LastPasswordChangeDateTime = DateTime.UtcNow.AddHours(4);
		}
		public void UpdateRefreshToken(string refreshToken)
		{
			RefreshToken = refreshToken;
		}

		public void UpdateOTP(string otp, DateTime expireDate)
		{
			OTP = otp;
			OTPExpireAt = expireDate;
		}

	}
}
