﻿using LuxRide.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Interfaces
{
	public interface IClaimManager
	{
		int GetCurrentUserId();
		IEnumerable<Claim> GetUserClaims(User user);

	}
}
