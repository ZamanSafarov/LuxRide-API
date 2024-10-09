using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities;
using LuxRide.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(LuxrideDbContext context) : base(context)
		{
		}
	}
}
