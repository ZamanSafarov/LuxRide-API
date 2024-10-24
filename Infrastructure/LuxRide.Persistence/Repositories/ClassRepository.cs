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
	public class ClassRepository : Repository<Class>, IClassRepository
	{
		public ClassRepository(LuxrideDbContext context) : base(context)
		{
		}
	}
}
