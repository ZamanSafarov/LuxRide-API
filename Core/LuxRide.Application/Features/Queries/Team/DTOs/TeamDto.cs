using LuxRide.Application.Features.Commands.Team.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Team.DTOs
{
	public class TeamDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime RecordDateTime { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Path { get; set; }
		public List<ExperienceDto> Experiences { get; set; }
	}
}
