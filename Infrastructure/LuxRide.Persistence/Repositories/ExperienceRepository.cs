using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Teams;
using LuxRide.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.Repositories
{
	public class ExperienceRepository : Repository<Experience>, IExperienceRepository
	{
		private readonly LuxrideDbContext _context;	 	
		public ExperienceRepository(LuxrideDbContext context) : base(context)
		{
			_context = context;
		}
		public async Task RemoveRange(IEnumerable<Experience> experiences)
		{
			_context.Set<Experience>().RemoveRange(experiences);
		}
	}
}
