using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Fleets
{
	public class TimeSlot:Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public TimeSpan StartTime { get; private set; }
		public TimeSpan EndTime { get;private set; }
		public bool IsAvailable { get;private set; }

		public void SetDetails(TimeSpan startTime, TimeSpan endTime,bool isAvailable)
		{
			StartTime = startTime;
			EndTime = endTime;
			IsAvailable = isAvailable;
		}
	}

}
