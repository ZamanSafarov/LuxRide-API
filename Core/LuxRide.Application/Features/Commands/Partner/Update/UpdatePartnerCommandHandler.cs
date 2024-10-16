using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Partner.Update;
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

namespace LuxRide.Application.Features.Commands.Partner.Update
{
	public class UpdatePartnerCommandHandler : IRequestHandler<UpdatePartnerCommand, bool>
	{
		private readonly IUserManager _userManager;
		private readonly IPartnerRepository _partnerRepository;
		private readonly IOptions<FileSettings> _fileSettings;

		public UpdatePartnerCommandHandler(IUserManager userManager, IPartnerRepository partnerRepository , IOptions<FileSettings> fileSettings)
		{
			_userManager = userManager;
			_partnerRepository = partnerRepository;
			_fileSettings = fileSettings;
		}

		public async Task<bool> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
		{
			var userId = _userManager.GetCurrentUserId();
			var partner = await _partnerRepository.GetAsync(x => x.Id == request.Id);
			if (partner == null)
				throw new NotFoundException("Partner Not Found");

			if (request.Photo is not null)
			{
				if (request.Photo.IsImage())
				{
					(string path, string fileName) = await request.Photo.SaveAsync(_fileSettings.Value.CreateSubFolders(_fileSettings.Value.Path,
					_fileSettings.Value.PartnerSettings.PartnerName,
						partner.RecordDateTime.ToString(), _fileSettings.Value.PartnerSettings.Photos));
					if (File.Exists(partner.Path))
					{
						File.Delete(partner.Path);
					}
					partner.SetDetails(request.Name, path);


				}
				else
				{
					throw new ExtensionException("File content is not Valid. Please upload image.");
				}

			}
			else
			{
				partner.SetDetails(request.Name,partner.Path);

			}
		
			partner.SetEditFields(userId);


			await _partnerRepository.Update(partner);
			await _partnerRepository.Commit();
			return true;
		}
	}
}
