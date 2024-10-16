using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Queries.Partner.DTOs;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Partner.Get
{
	public class GetPartnerByIdQueryHandler : IRequestHandler<GetPartnerByIdQuery, PartnerDto>
	{
		private readonly IPartnerRepository _partnerRepository;

		public GetPartnerByIdQueryHandler(IPartnerRepository partnerRepository)
		{
			_partnerRepository = partnerRepository;
		}

		public async Task<PartnerDto> Handle(GetPartnerByIdQuery request, CancellationToken cancellationToken)
		{
			var partner = await _partnerRepository.GetAsync(x=>x.Id == request.Id);

			if (partner is null)
				throw new NotFoundException("Partner Not Found.");
			return new PartnerDto
			{
				Id = partner.Id,
				Name = partner.Name,
				Path = partner.Path,
				RecordDateTime = partner .RecordDateTime

			};
		}
	}
}
