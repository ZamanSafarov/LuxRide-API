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
	internal class UpdateFaqCommandHandler : IRequestHandler<UpdateFaqCommand, bool>
	{
		private readonly IFaqRepository _faqRepository;
		private readonly IUserManager _userManager;

		public UpdateFaqCommandHandler(IFaqRepository faqRepository, IUserManager userManager)
		{
			_faqRepository = faqRepository;
			_userManager = userManager;
		}

		public async Task<bool> Handle(UpdateFaqCommand request, CancellationToken cancellationToken)
		{
			var userId= _userManager.GetCurrentUserId();
			var faq = await _faqRepository.GetAsync(x => x.Id == request.Id);

			if (faq is null)
				throw new NotFoundException("Faq not found");

			faq.SetDetails(request.Question,request.Answer);

			faq.SetEditFields(userId);

			await _faqRepository.Update(faq);
			await _faqRepository.Commit();

			return true;
		}
	}
}
