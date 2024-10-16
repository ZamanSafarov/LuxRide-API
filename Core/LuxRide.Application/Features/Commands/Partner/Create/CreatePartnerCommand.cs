using LuxRide.Application.Features.Commands.Team.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Partner.Create
{
	public class CreatePartnerCommand : IRequest<bool>
	{
		public string Name { get;  set; }
		public IFormFile Photo { get; set; }

	}
}
