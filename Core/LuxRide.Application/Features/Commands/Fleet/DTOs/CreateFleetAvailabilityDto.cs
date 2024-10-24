using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Fleet.DTOs
{
	public class CreateFleetAvailabilityDto
	{
		public DateTime Date { get; set; }
		public List<CreateTimeSlotDto> AvailableTimeSlots { get; set; }
		public bool IsAvailable { get; set; }
	}
}
