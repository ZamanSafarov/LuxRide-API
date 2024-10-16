using LuxRide.Application.Common.Pagination;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Team.DTOs;
using LuxRide.Application.Features.Queries.Partner.DTOs;
using LuxRide.Application.Features.Queries.Team.DTOs;
using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Teams;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Partner.Get
{
	public class GetPartnerAllQueryHandler : IRequestHandler<GetPartnerAllQuery,List<PartnerDto>>
	{
		private readonly IPartnerRepository _partnerRepository;

		public GetPartnerAllQueryHandler(IPartnerRepository partnerRepository)
		{
			_partnerRepository = partnerRepository;
		}

		public async Task<List<PartnerDto>> Handle(GetPartnerAllQuery request, CancellationToken cancellationToken)
		{
			var query = await _partnerRepository.GetAllAsync();


			if (query is null)
				throw new NotFoundException("Partners  Not Found.");

			var partners = new List<PartnerDto>();

			foreach (var item in query)
			{
				var partner = new PartnerDto()
				{
					Id = item.Id,
					Name = item.Name,
					Path = item.Path,
					RecordDateTime = item.RecordDateTime,
				};
				partners.Add(partner);
			}

			return partners;
		}
	}
}
