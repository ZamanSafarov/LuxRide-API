using LuxRide.Application.Features.Commands.Team.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.About.Create
{
	public class CreateAboutCommand:IRequest<bool>
	{
		public string Title { get;  set; }
		public string Description { get;  set; }
		public IFormFile Photo { get; set; }

	}
}
