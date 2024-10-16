using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Contacts;
using LuxRide.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.Repositories
{
	public class ContactRepository : Repository<Contact>, IContactRepository
	{
		public ContactRepository(LuxrideDbContext context) : base(context)
		{
		}
	}
}
