using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Brand.Create
{
	public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, bool>
	{
		private readonly IBrandRepository _brandRepository;
		private readonly IUserManager _userManager;

		public CreateBrandCommandHandler(IUserManager userManager, IBrandRepository brandRepository)
		{
			_userManager = userManager;
			_brandRepository = brandRepository;
		}

		public async Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
		{
			var userId = _userManager.GetCurrentUserId();

			var brand = new Domain.Entities.Fleets.Brand();

			brand.SetDetails(request.Name);

			brand.SetAuditDetails(userId);

			await _brandRepository.AddAsync(brand);
			await _brandRepository.Commit();

			return true;
		}
	}
}
