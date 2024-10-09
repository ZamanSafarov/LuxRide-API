using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Teams;
using LuxRide.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.Repositories
{
	public class TeamRepository : Repository<Team>, ITeamRepository
	{
		public TeamRepository(LuxrideDbContext context) : base(context)
		{
		}
	}
}
