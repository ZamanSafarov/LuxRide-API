using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Team.DTOs;
using LuxRide.Application.Features.Queries.Brand.DTOs;
using LuxRide.Application.Features.Queries.Team.DTOs;
using LuxRide.Application.Features.Queries.Team.Get;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Brand.Get
{
	public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
	{
		private readonly IBrandRepository _brandRepository;
        public GetBrandByIdQueryHandler(IBrandRepository brandRepository)
        {
				_brandRepository = brandRepository;
        }


        public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
		{
			var brand = await _brandRepository.GetAsync(x => x.Id == request.Id);

			if (brand is null)
				throw new NotFoundException("Brand Not Found.");

			return new BrandDto
			{
				Id = brand.Id,
				Name = brand.Name
			};
		}
	}
}
