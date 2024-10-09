using LuxRide.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain
{
	public class Editable<TUser> : Auditable<TUser> where TUser : User
	{
		public int? UpdateById { get; protected set; }
		public DateTime? LastUpdateDateTime { get; protected set; }

		public void SetEditFields(int? updatedById)
		{

			UpdateById = updatedById;
			LastUpdateDateTime = DateTime.UtcNow.AddHours(4);
		}
	}
}
