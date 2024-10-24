using LuxRide.Application.Features.Commands.Fleet.DTOs;
using LuxRide.Domain.Entities.Fleets;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Fleet.Create
{
	public class FleetCreateCommand:IRequest<int>
	{
		public string Name { get;  set; }
		public int BrandId { get; set; }
		public int ClassId { get; set; }
		public int PassangerCapacity { get;  set; }
		public List<CreateFleetImagesDto> FleetImages { get; set; }
		public List<CreateFleetAvailabilityDto> FleetAvailabilities { get; set; }
		public bool IsAvailable { get; set; }
		public decimal HourlyRate { get; set; }
		public decimal DailyRate { get; set; }
		public decimal AirportTransferRate { get; set; }
	}
}
