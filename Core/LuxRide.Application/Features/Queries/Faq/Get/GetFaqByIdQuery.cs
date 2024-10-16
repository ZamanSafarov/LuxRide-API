using LuxRide.Application.Features.Queries.Faq.DTOs;
using LuxRide.Application.Features.Queries.Team.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Faq.Get
{
	public class GetFaqByIdQuery: IRequest<FaqDto>
	{
		public int Id { get; set; }
	}
}
