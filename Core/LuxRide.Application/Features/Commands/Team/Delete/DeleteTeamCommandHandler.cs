using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Team.Delete
{
	public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, bool>
	{
		private readonly ITeamRepository _teamRepository;

		public DeleteTeamCommandHandler(ITeamRepository teamRepository)
		{
			_teamRepository = teamRepository;
		}

		public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
		{
			var team = await _teamRepository.GetAsync(t=>t.Id==request.Id,"Experiences");

			if (team is null)
				throw new NotFoundException("Team not found.");

			if (File.Exists(team.Path))
			{
				File.Delete(team.Path);
			}
			await _teamRepository.HardDeleteAsync(team);
			await _teamRepository.Commit();
		
			return true;
		}
	}
}
