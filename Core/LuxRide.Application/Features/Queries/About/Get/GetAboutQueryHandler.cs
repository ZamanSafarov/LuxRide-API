using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Queries.About.DTOs;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.About.Get
{
	public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, AboutDto>
	{
		private readonly IAboutRepository _aboutRepository;

		public GetAboutQueryHandler(IAboutRepository aboutRepository)
		{
			_aboutRepository = aboutRepository;
		}

		public async Task<AboutDto> Handle(GetAboutQuery request, CancellationToken cancellationToken)
		{
			var abouts = await _aboutRepository.GetAllAsync();
			if (abouts == null)
				throw new NotFoundException("About  Not Found.");


			var about = abouts.FirstOrDefault();
			return new AboutDto
			{
				Id = about.Id,
				Title = about.Title,
				Description= about.Description,
				Path = about.Path
			};
		}
	}
}
