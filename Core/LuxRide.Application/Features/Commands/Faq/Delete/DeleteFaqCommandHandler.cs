using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Faq.Create
{
	public class DeleteFaqCommandHandler : IRequestHandler<DeleteFaqCommand, bool>
	{
		private readonly IFaqRepository _faqRepository;

		public DeleteFaqCommandHandler( IFaqRepository faqRepository)
		{
			_faqRepository = faqRepository;
		}

		public async Task<bool> Handle(DeleteFaqCommand request, CancellationToken cancellationToken)
		{
			var faq = await _faqRepository.GetAsync(x => x.Id == request.Id);

			if (faq is null)
				throw new NotFoundException("Faq not found");

			await _faqRepository.HardDeleteAsync(faq);
			await _faqRepository.Commit();

			return true;
		}
	}
}
