using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Abouts;
using LuxRide.Domain.Entities.Teams;
using LuxRide.Infrastructure;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.About.Create
{
	public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, bool>
	{
		private readonly IAboutRepository _aboutRepository;
		private readonly IUserManager _userManager;
		private readonly IOptions<FileSettings> _fileSettings;

		public CreateAboutCommandHandler(IAboutRepository aboutRepository,
			IUserManager userManager,
			IOptions<FileSettings> fileSettings)
		{
			_aboutRepository = aboutRepository;
			_userManager = userManager;
			_fileSettings = fileSettings;
		}


		public async Task<bool> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
		{
			var aboutsCound = await _aboutRepository.GetAllAsync();

			if (aboutsCound.Count() == 1)
				throw new BadRequestException("Only 1 About can Create");


			var userId = _userManager.GetCurrentUserId();
			var about = new Domain.Entities.Abouts.About();


			if (request.Photo.IsImage()==false)
				throw new ExtensionException("File Type is not Valid. Please upload image.");


			(string path, string fileName) = await request.Photo.SaveAsync(_fileSettings.Value.CreateSubFolders(_fileSettings.Value.Path,
					_fileSettings.Value.AboutSettings.AboutName,
					request.Title, _fileSettings.Value.AboutSettings.Photos));

				about.SetDetails(path, request.Title, request.Description);
		

			about.SetAuditDetails(userId);




			await _aboutRepository.AddAsync(about);
			await _aboutRepository.Commit();
			return true;
			
			
		}

	}
}
