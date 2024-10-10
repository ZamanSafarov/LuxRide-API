using LuxRide.Application.Common.Pagination;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Team.DTOs;
using LuxRide.Application.Features.Queries.Team.DTOs;
using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Teams;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Team.Get
{
	public class GetAllQueryHandler : IRequestHandler<GetAllQuery, PaginatedResult<TeamDto>>
	{
		private readonly ITeamRepository _teamRepository;

		public GetAllQueryHandler(ITeamRepository teamRepository)
		{
			_teamRepository = teamRepository;
		}

		public async Task<PaginatedResult<TeamDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
		{
			var query = await _teamRepository.GetAllAsync(null,"Experiences");


			if (query is null)
				throw new NotFoundException("Teams  Not Found.");
			var totalRecords = query.Count();

		
			var teams = query
				.Skip((request.PageNumber - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(c => new TeamDto
				{
					Id = c.Id,
					Name = c.Name,
					Path = c.Path,
					Email = c.Email,
					Phone = c.Phone,
					Experiences = c.Experiences.Select(experience => new ExperienceDto()
					{
						CompanyName = experience.CompanyName,
						JobDescription = experience.JobDescription,
						JobTitle = experience.JobTitle,
						StartDate = experience.StartDate,
						EndDate = experience.EndDate,
						IsPresent = experience.IsPresent,

					}).ToList(),
					RecordDateTime = c.RecordDateTime
				})
				.ToList();
			var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);
			return new PaginatedResult<TeamDto>
			{
				CurrentPage = request.PageNumber,
				PageSize = request.PageSize,
				TotalCount = totalRecords,
				TotalPages = totalPages,
				Data = teams
			};
		}
	}
}
