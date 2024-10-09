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
	public class ExperienceRepository : Repository<Experience>, IExperienceRepository
	{
		public ExperienceRepository(LuxrideDbContext context) : base(context)
		{
		}
	}
}
