using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Partner.Create;
using LuxRide.Application.Interfaces;
using LuxRide.Infrastructure;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Partner.Create
{
	public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, bool>
	{
		private readonly IPartnerRepository _partnerRepository;
		private readonly IUserManager _userManager;
		private readonly IOptions<FileSettings> _fileSettings;

		public CreatePartnerCommandHandler(IPartnerRepository partnerRepository,
			IUserManager userManager,
			IOptions<FileSettings> fileSettings)
		{
			_partnerRepository = partnerRepository;
			_userManager = userManager;
			_fileSettings = fileSettings;
		}


		public async Task<bool> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
		{
			var userId = _userManager.GetCurrentUserId();
			var partner = new Domain.Entities.Abouts.Partner();


			if (request.Photo.IsImage()==false)
				throw new ExtensionException("File Type is not Valid. Please upload image.");


			(string path, string fileName) = await request.Photo.SaveAsync(_fileSettings.Value.CreateSubFolders(_fileSettings.Value.Path,
					_fileSettings.Value.PartnerSettings.PartnerName,
					request.Name, _fileSettings.Value.PartnerSettings.Photos));

			partner.SetDetails(request.Name, path);


			partner.SetAuditDetails(userId);




			await _partnerRepository.AddAsync(partner);
			await _partnerRepository.Commit();
			return true;
			
			
		}

	}
}
