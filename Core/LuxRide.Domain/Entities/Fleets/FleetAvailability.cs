using LuxRide.Domain.Common;
using LuxRide.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Fleets
{
	public class FleetAvailability:Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public int FleetId { get;  set; }
		public Fleet Fleet { get;  set; } 

		public DateTime Date { get; private set; }
		public List<TimeSlot> AvailableTimeSlots { get; private set; }

		public bool IsAvailable { get; private set; }

        public FleetAvailability()
        {
				AvailableTimeSlots = new List<TimeSlot>();
        }
        public void SetDetails(DateTime date,bool isAvailable)
		{
			Date = date.Kind == DateTimeKind.Utc ? date : date.ToUniversalTime();
			IsAvailable = isAvailable;
		}
		public List<TimeSlot> GetAvailableTimeSlots(BookingType bookingType)
		{
			if (bookingType == BookingType.Hourly)
			{
				return AvailableTimeSlots.FindAll(slot => slot.IsAvailable);
			}
			return new List<TimeSlot>();
		}
	}

}
