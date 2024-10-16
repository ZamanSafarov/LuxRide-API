using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.About.Update;
using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Teams;
using LuxRide.Infrastructure;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.About.Update
{
	public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, bool>
	{
		private readonly IUserManager _userManager;
		private readonly IAboutRepository _aboutRepository;
		private readonly IOptions<FileSettings> _fileSettings;

		public UpdateAboutCommandHandler(IUserManager userManager, IAboutRepository aboutRepository , IOptions<FileSettings> fileSettings)
		{
			_userManager = userManager;
			_aboutRepository = aboutRepository;
			_fileSettings = fileSettings;
		}

		public async Task<bool> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
		{
			var userId = _userManager.GetCurrentUserId();
			var about = await _aboutRepository.GetAsync(x => x.Id == request.Id);
			if (about == null)
				throw new NotFoundException("About Not Found");

			if (request.Photo is not null)
			{
				if (request.Photo.IsImage())
				{
					(string path, string fileName) = await request.Photo.SaveAsync(_fileSettings.Value.CreateSubFolders(_fileSettings.Value.Path,
					_fileSettings.Value.AboutSettings.AboutName,
						about.RecordDateTime.ToString(), _fileSettings.Value.AboutSettings.Photos));
					if (File.Exists(about.Path))
					{
						File.Delete(about.Path);
					}
					about.SetDetails(path, request.Title, request.Description);


				}
				else
				{
					throw new ExtensionException("File content is not Valid. Please upload image.");
				}

			}
			else
			{
				about.SetDetails(about.Path, request.Title, request.Description);

			}
		
			about.SetEditFields(userId);


			await _aboutRepository.Update(about);
			await _aboutRepository.Commit();
			return true;
		}
	}
}
