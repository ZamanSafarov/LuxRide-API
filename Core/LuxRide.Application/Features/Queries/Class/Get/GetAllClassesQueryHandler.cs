using LuxRide.Application.Common.Pagination;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Team.DTOs;
using LuxRide.Application.Features.Queries.Class.DTOs;
using LuxRide.Application.Features.Queries.Team.DTOs;
using LuxRide.Application.Features.Queries.Team.Get;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Class.Get
{
	public class GetAllClassesQueryHandler: IRequestHandler<GetAllClassesQuery, PaginatedResult<ClassDto>>
	{
		private readonly IClassRepository _classRepository;

		public GetAllClassesQueryHandler(IClassRepository classRepository)
		{
			_classRepository = classRepository;
		}

		public async Task<PaginatedResult<ClassDto>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
		{
			var query = await _classRepository.GetAllAsync();


			if (query is null)
				throw new NotFoundException("Classes Not Found.");

			var totalRecords = query.Count();


			var classes = query
				.Skip((request.PageNumber - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(c => new ClassDto
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToList();
			var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);
			return new PaginatedResult<ClassDto>
			{
				CurrentPage = request.PageNumber,
				PageSize = request.PageSize,
				TotalCount = totalRecords,
				TotalPages = totalPages,
				Data = classes
			};
		}
	}
}
