using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Fleets;
using LuxRide.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.Repositories
{
	public class FleetRepository : Repository<Fleet>, IFleetRepository
	{
		public FleetRepository(LuxrideDbContext context) : base(context)
		{
		}
	}
}
