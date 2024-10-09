using LuxRide.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Interfaces
{
	public interface IUserManager
	{
		public int GetCurrentUserId();
		(string token, DateTime expireAt) GenerateJwtToken(User user);
	}
}
