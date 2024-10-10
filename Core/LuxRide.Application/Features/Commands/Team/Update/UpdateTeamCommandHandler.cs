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

namespace LuxRide.Application.Features.Commands.Team.Update
{
	public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, bool>
	{
		private readonly IUserManager _userManager;
		private readonly ITeamRepository _teamRepository;
		private readonly IExperienceRepository _experienceRepository;
		private readonly IOptions<FileSettings> _fileSettings;

		public UpdateTeamCommandHandler(IUserManager userManager, ITeamRepository teamRepository, IExperienceRepository experienceRepository, IOptions<FileSettings> fileSettings)
		{
			_userManager = userManager;
			_teamRepository = teamRepository;
			_experienceRepository = experienceRepository;
			_fileSettings = fileSettings;
		}

		public async Task<bool> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
		{
			var userId = _userManager.GetCurrentUserId();
			var team = await _teamRepository.GetAsync(x => x.Id == request.Id);
			if (team == null)
				throw new NotFoundException("Team Not Found");

			if (request.Photo is not null)
			{
				if (request.Photo.IsImage())
				{
					(string path, string fileName) = await request.Photo.SaveAsync(_fileSettings.Value.CreateSubFolders(_fileSettings.Value.Path,
					_fileSettings.Value.TeamSettings.TeamName,
						request.Email, _fileSettings.Value.TeamSettings.Photos));
					if (File.Exists(team.Path))
					{
						File.Delete(team.Path);
					}
					team.SetDetails(request.Name, request.Phone, request.Email, path);


				}
				else
				{
					throw new ExtensionException("File content is not Valid. Please upload image.");
				}

			}
			else
			{
				team.SetDetails(request.Name, request.Phone, request.Email,team.Path);
			}
		
			if (request.Experiences.Count!=0)
			{
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
			}
			team.SetEditFields(userId);


			if (request.DeletedExperiences.Count != 0)
			{
				var deletedExperiences = await _experienceRepository.GetAllAsync(x => request.DeletedExperiences.Contains(x.Id));
				
				await _experienceRepository.RemoveRange(deletedExperiences);
				await _experienceRepository.Commit();
			}
			await _teamRepository.Update(team);
			await _teamRepository.Commit();
			return true;
		}
	}
}
