using LuxRide.Application.Features.Queries.Team.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Team.Get
{
	public class GetByIdQuery:IRequest<TeamDto>
	{
		public int Id { get; set; }
	}
}
