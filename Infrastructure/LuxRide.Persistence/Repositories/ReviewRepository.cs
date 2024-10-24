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
	public class ReviewRepository : Repository<Review>, IReviewRepository
	{
		public ReviewRepository(LuxrideDbContext context) : base(context)
		{
		}
	}
}
