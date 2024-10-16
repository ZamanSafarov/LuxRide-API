using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.About.Delete
{
	public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand, bool>
	{
		private readonly IAboutRepository _aboutRepository;

		public DeleteAboutCommandHandler(IAboutRepository aboutRepository)
		{
			_aboutRepository = aboutRepository;
		}

		public async Task<bool> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
		{
			var about = await _aboutRepository.GetAsync(t=>t.Id==request.Id);

			if (about is null)
				throw new NotFoundException("About not found.");

			if (File.Exists(about.Path))
			{
				File.Delete(about.Path);
			}
			await _aboutRepository.HardDeleteAsync(about);
			await _aboutRepository.Commit();
		
			return true;
		}
	}
}
