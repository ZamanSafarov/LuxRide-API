using LuxRide.Application.Common.Pagination;
using LuxRide.Application.Features.Queries.Contact.DTOs;
using LuxRide.Domain.Entities.Contacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Contact.Get
{
	public class GetAllContactQuery:IRequest<PaginatedResult<ContactDto>>
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
