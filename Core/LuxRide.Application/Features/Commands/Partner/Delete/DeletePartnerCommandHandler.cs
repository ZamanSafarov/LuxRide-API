using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Partner.Delete
{
	public class DeletePartnerCommandHandler : IRequestHandler<DeletePartnerCommand, bool>
	{
		private readonly IPartnerRepository _partnerRepository;

		public DeletePartnerCommandHandler(IPartnerRepository partnerRepository)
		{
			_partnerRepository = partnerRepository;
		}

		public async Task<bool> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
		{
			var partner = await _partnerRepository.GetAsync(t=>t.Id==request.Id);

			if (partner is null)
				throw new NotFoundException("Partner not found.");

			if (File.Exists(partner.Path))
			{
				File.Delete(partner.Path);
			}
			await _partnerRepository.HardDeleteAsync(partner);
			await _partnerRepository.Commit();
		
			return true;
		}
	}
}
