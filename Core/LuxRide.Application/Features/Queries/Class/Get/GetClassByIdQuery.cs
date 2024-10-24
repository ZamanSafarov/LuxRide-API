using LuxRide.Application.Features.Queries.Class.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Class.Get
{
	public class GetClassByIdQuery: IRequest<ClassDto>
	{
		public int Id { get; set; }
	}
}
