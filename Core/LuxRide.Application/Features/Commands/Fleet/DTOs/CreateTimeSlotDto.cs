using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Fleet.DTOs
{
	public class CreateTimeSlotDto
	{
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
		public bool IsAvailable { get; set; }
	}
}
