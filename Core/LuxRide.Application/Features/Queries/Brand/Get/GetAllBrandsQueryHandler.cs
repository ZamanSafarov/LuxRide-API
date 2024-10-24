using LuxRide.Application.Common.Pagination;
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
	public class GetAllBrandsQueryHandler: IRequestHandler<GetAllBrandsQuery, PaginatedResult<BrandDto>>
	{
		private readonly IBrandRepository _brandRepository;

		public GetAllBrandsQueryHandler(IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		public async Task<PaginatedResult<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
		{
			var query = await _brandRepository.GetAllAsync();


			if (query is null)
				throw new NotFoundException("Brands Not Found.");

			var totalRecords = query.Count();


			var brands = query
				.Skip((request.PageNumber - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(c => new BrandDto
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToList();
			var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);
			return new PaginatedResult<BrandDto>
			{
				CurrentPage = request.PageNumber,
				PageSize = request.PageSize,
				TotalCount = totalRecords,
				TotalPages = totalPages,
				Data = brands
			};
		}
	}
}
