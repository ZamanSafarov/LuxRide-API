using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Teams;
using LuxRide.Infrastructure;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Team.Create
{
	public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, bool>
	{
		private readonly ITeamRepository _teamRepository;
		private readonly IUserManager _userManager;
		private readonly IOptions<FileSettings> _fileSettings;

		public CreateTeamCommandHandler(ITeamRepository teamRepository,
			IUserManager userManager,
			IOptions<FileSettings> fileSettings)
		{
			_teamRepository = teamRepository;
			_userManager = userManager;
			_fileSettings = fileSettings;
		}


		public async Task<bool> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var userId = _userManager.GetCurrentUserId();
				Domain.Entities.Teams.Team team = new Domain.Entities.Teams.Team();

				// Setting team details
				if (request.Photo.IsImage())
				{
					(string path, string fileName) = await request.Photo.SaveAsync(_fileSettings.Value.CreateSubFolders(_fileSettings.Value.Path,
						_fileSettings.Value.TeamSettings.TeamName,
						request.Email, _fileSettings.Value.TeamSettings.Photos));
					team.SetDetails(request.Name, request.Phone, request.Email, path);
				}
				else
				{
					throw new ExtensionException("File Type is not Valid. Please upload image.");
				}

				team.SetAuditDetails(userId);
				

				for (int i = 0; i < request.Experiences.Count; i++)
				{
					var experience = new Experience();
					experience.SetDetails(request.Experiences[i].JobTitle, request.Experiences[i].JobDescription, request.Experiences[i].CompanyName);

					var startDateUtc = request.Experiences[i].StartDate.ToUniversalTime();
					var endDateUtc = request.Experiences[i].EndDate?.ToUniversalTime();
					experience.SetExperienceDate(startDateUtc, endDateUtc, request.Experiences[i].IsPresent);
					experience.SetAuditDetails(userId);

					team.Experiences.Add(experience);
				}

				await _teamRepository.AddAsync(team);
				await _teamRepository.Commit();

				return true;
			}
			catch (Exception ex)
			{
				// Catching and logging the full exception details
				Console.WriteLine("An error occurred: " + ex.Message);
				if (ex.InnerException != null)
				{
					Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
				}
				throw;
			}
		}

	}
}
