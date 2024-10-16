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
	public class GetFaqByIdQueryHandler : IRequestHandler<GetFaqByIdQuery, FaqDto>
	{
		private readonly IFaqRepository _faqRepository;
        public GetFaqByIdQueryHandler(IFaqRepository faqRepository)
        {
				_faqRepository = faqRepository;
        }


        public async Task<FaqDto> Handle(GetFaqByIdQuery request, CancellationToken cancellationToken)
		{
			var team = await _faqRepository.GetAsync(x => x.Id == request.Id);

			if (team is null)
				throw new NotFoundException("Team Not Found.");

			return new FaqDto
			{
				Id = team.Id,
				Answer = team.Answer,
				Question = team.Question,
				RecordDateTime = team.RecordDateTime

			};
		}
	}
}
