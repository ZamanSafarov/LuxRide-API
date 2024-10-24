using LuxRide.Application.Features.Queries.Brand.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Brand.Get
{
	public class GetBrandByIdQuery: IRequest<BrandDto>
	{
		public int Id { get; set; }
	}
}
