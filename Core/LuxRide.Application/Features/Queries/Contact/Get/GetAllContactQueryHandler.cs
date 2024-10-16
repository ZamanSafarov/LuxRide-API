using LuxRide.Application.Common.Pagination;
using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Commands.Team.DTOs;
using LuxRide.Application.Features.Queries.Contact.DTOs;
using LuxRide.Application.Features.Queries.Team.DTOs;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Contact.Get
{
	public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, PaginatedResult<ContactDto>>
	{
		private readonly IContactRepository _contactRepository;

		public GetAllContactQueryHandler(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}

		public async Task<PaginatedResult<ContactDto>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
		{

			var query = await _contactRepository.GetAllAsync();
			if (query is null)
				throw new NotFoundException("Contacts  Not Found.");
			var totalRecords = query.Count();


			var contacts = query
				.Skip((request.PageNumber - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(c => new ContactDto
				{
					Id = c.Id,
					Name = c.Name,
					Subject = c.Subject,
					Email = c.Email,
					Message = c.Message,
					RecordDateTime = c.RecordDateTime
				})
				.ToList();
			var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

			return new PaginatedResult<ContactDto>
			{
				CurrentPage = request.PageNumber,
				PageSize = request.PageSize,
				TotalCount = totalRecords,
				TotalPages = totalPages,
				Data = contacts
			};
		}
	}
}
