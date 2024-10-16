using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Abouts;
using LuxRide.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.Repositories
{
	public class PartnerRepository : Repository<Partner>, IPartnerRepository
	{
		public PartnerRepository(LuxrideDbContext context) : base(context)
		{
		}
	}
}
