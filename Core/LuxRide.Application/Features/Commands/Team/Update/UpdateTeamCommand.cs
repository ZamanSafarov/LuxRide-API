using LuxRide.Application.Features.Commands.Team.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Team.Update
{
	public class UpdateTeamCommand:IRequest<bool>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public IFormFile? Photo { get; set; }
		public List<ExperienceDto> Experiences { get; set; }
		public List<int> DeletedExperiences { get; set; }
	}
}
