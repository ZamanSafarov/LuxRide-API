using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Fleet.DTOs
{
	public class CreateFleetImagesDto
	{
		public IFormFile FleetImage { get; set; }
		public bool IsMain { get; set; }
	}
}
