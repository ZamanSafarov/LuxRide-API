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
	public class GetClassByIdQueryHandler : IRequestHandler<GetClassByIdQuery, ClassDto>
	{
		private readonly IClassRepository _classRepository;
        public GetClassByIdQueryHandler(IClassRepository classRepository)
        {
			_classRepository = classRepository;
        }


        public async Task<ClassDto> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
		{
			var clas = await _classRepository.GetAsync(x => x.Id == request.Id);

			if (clas is null)
				throw new NotFoundException("Class Not Found.");

			return new ClassDto
			{
				Id = clas.Id,
				Name = clas.Name
			};
		}
	}
}
