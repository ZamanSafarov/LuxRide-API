using LuxRide.Application.Common.Pagination;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Team.DTOs;
using LuxRide.Application.Features.Queries.Partner.DTOs;
using LuxRide.Application.Features.Queries.Review.DTOs;
using LuxRide.Application.Features.Queries.Review.Get;
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
	public class GetReviewAllQueryHandler : IRequestHandler<GetReviewAllQuery, PaginatedResult<ReviewDto>>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetReviewAllQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<PaginatedResult<ReviewDto>> Handle(GetReviewAllQuery request, CancellationToken cancellationToken)
		{
			var query = await _reviewRepository.GetAllAsync();

			if (query is null)
				throw new NotFoundException("Reviews  Not Found.");

			var totalRecords = query.Count();

			var partners = query
				.Skip((request.PageNumber - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(c => new ReviewDto
				{
					Id = c.Id,
					Name = c.Name,
					Path = c.Path,
					Content = c.Content,
					Position = c.Position,
					Rate = c.Rate,
					RecordDateTime = c.RecordDateTime
				})
				.ToList();

			var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);
			return new PaginatedResult<ReviewDto>
			{
				CurrentPage = request.PageNumber,
				PageSize = request.PageSize,
				TotalCount = totalRecords,
				TotalPages = totalPages,
				Data = partners
			};


		}
	}
}
