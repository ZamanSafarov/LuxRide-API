using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Fleets
{
	public class FleetImage:Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public string Path { get; private set; }
		public	bool  IsMain { get; private set; }

		public Fleet Fleet { get; set; }
		public int FleetId { get; set; }
		public void SetDetails(string path,bool isMain)
		{
			Path = path;
			IsMain = isMain;
		}

	}
}
