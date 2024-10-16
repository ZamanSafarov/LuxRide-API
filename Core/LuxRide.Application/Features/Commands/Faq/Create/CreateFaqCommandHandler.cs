using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Faq.Create
{
	public class CreateFaqCommandHandler : IRequestHandler<CreateFaqCommand, bool>
	{
		private readonly IFaqRepository _faqRepository;
		private readonly IUserManager _userManager;

		public CreateFaqCommandHandler(IUserManager userManager, IFaqRepository faqRepository)
		{
			_userManager = userManager;
			_faqRepository = faqRepository;
		}

		public async Task<bool> Handle(CreateFaqCommand request, CancellationToken cancellationToken)
		{
			var userId = _userManager.GetCurrentUserId();

			var faq = new Domain.Entities.Abouts.Faq();

			faq.SetDetails(request.Question, request.Answer);

			faq.SetAuditDetails(userId);

			await _faqRepository.AddAsync(faq);
			await _faqRepository.Commit();

			return true;
		}
	}
}
