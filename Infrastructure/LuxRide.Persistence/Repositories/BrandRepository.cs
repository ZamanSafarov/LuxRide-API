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
	public class BrandRepository : Repository<Brand>, IBrandRepository
	{
		public BrandRepository(LuxrideDbContext context) : base(context)
		{
		}
	}
}
