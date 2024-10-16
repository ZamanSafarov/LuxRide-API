using LuxRide.Domain.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Interfaces
{
	public interface IContactRepository:IRepository<Contact>
	{
	}
}
