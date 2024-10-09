using LuxRide.Domain.Common;
using LuxRide.Domain.Entities;
using LuxRide.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain
{
	public class Auditable<TUser> : IBaseEntity where TUser : User
	{
		public int CreatedById { get; protected set; }
		public DateTime RecordDateTime { get; protected set; }
		public int Id { get; set; }

		public void SetAuditDetails(int createdById)
		{
			if (CreatedById != 0 && CreatedById != createdById)
			{
				throw new DomainException("CreatedBy already set.");
			}
			CreatedById = createdById;
			RecordDateTime = DateTime.UtcNow.AddHours(4);
		}
	}
}
