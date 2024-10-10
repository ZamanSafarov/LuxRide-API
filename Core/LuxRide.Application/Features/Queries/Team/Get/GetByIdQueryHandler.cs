using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Team.DTOs;
using LuxRide.Application.Features.Queries.Team.DTOs;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Team.Get
{
	public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, TeamDto>
	{
		private readonly ITeamRepository _teamRepository;

		public GetByIdQueryHandler(ITeamRepository teamRepository)
		{
			_teamRepository = teamRepository;
		}

		public async Task<TeamDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
		{
			var team = await _teamRepository.GetAsync(x=>x.Id == request.Id, "Experiences");

			if (team is null)
				throw new NotFoundException("Team Not Found.");
			return new TeamDto
			{
				Id = team.Id,
				Name = team.Name,
				Path = team.Path,
				Email = team.Email,
				Phone = team.Phone,
				Experiences = team.Experiences.Select(experience => new ExperienceDto()
				{
					CompanyName = experience.CompanyName,
					JobDescription = experience.JobDescription,
					JobTitle = experience.JobTitle,
					StartDate = experience.StartDate,
					EndDate = experience.EndDate,
					IsPresent = experience.IsPresent,

				}).ToList(),
				RecordDateTime = team .RecordDateTime

			};
		}
	}
}
