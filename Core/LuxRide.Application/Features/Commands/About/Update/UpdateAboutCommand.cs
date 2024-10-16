using LuxRide.Application.Features.Commands.Team.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.About.Update
{
	public class UpdateAboutCommand:IRequest<bool>
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public IFormFile? Photo { get; set; }
	}
}
