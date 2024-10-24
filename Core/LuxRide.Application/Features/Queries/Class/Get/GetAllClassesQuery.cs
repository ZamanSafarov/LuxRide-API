using LuxRide.Application.Common.Pagination;
using LuxRide.Application.Features.Queries.Class.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Class.Get
{
	public class GetAllClassesQuery : IRequest<PaginatedResult<ClassDto>>
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
