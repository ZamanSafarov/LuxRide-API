using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Fleets
{
	public class Class:Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Fleet>? Fleets { get; set; }
		public void SetDetails(string name)
		{
			Name = name;
		}

	}
}
