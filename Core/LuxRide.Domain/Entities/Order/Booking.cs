using LuxRide.Domain.Common;
using LuxRide.Domain.Entities.Enums;
using LuxRide.Domain.Entities.Fleets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Order
{
	public class Booking:Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public DateTime BookingDate { get; set; } // Date selected by the user
		public TimeSpan? StartTime { get; set; } // Time slot for hourly bookings

		public BookingType BookingType { get; set; }

		public int FleetId { get; set; } // Associated Fleet
		public Fleet Fleet { get; set; }
	

		public Customer Customer { get; set; } // Customer details

		public int FleetAvailabilityId { get; set; } // Reference to FleetAvailability
		public FleetAvailability FleetAvailability { get; set; } // Fleet's availability at specific time slot
		public decimal TotalPrice { get; set; }
		public BookingStatus Status { get; set; } 

		public string? Notes { get; set; } 


	}
}
