using LuxRide.Application.Common.Pagination;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Team.DTOs;
using LuxRide.Application.Features.Queries.Faq.DTOs;
using LuxRide.Application.Features.Queries.Team.DTOs;
using LuxRide.Application.Features.Queries.Team.Get;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Faq.Get
{
	public class GetAllFaqsQueryHandler: IRequestHandler<GetAllFaqsQuery, PaginatedResult<FaqDto>>
	{
		private readonly IFaqRepository _faqRepository;

		public GetAllFaqsQueryHandler(IFaqRepository faqRepository)
		{
			_faqRepository = faqRepository;
		}

		public async Task<PaginatedResult<FaqDto>> Handle(GetAllFaqsQuery request, CancellationToken cancellationToken)
		{
			var query = await _faqRepository.GetAllAsync();


			if (query is null)
				throw new NotFoundException("Faqs Not Found.");

			var totalRecords = query.Count();


			var teams = query
				.Skip((request.PageNumber - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(c => new FaqDto
				{
					Id = c.Id,
					Answer = c.Answer,
					Question = c.Question,
					RecordDateTime = c.RecordDateTime
				})
				.ToList();
			var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);
			return new PaginatedResult<FaqDto>
			{
				CurrentPage = request.PageNumber,
				PageSize = request.PageSize,
				TotalCount = totalRecords,
				TotalPages = totalPages,
				Data = teams
			};
		}
	}
}
