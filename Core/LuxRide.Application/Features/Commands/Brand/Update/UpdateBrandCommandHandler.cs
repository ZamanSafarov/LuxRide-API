using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Brand.Create
{
	internal class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
	{
		private readonly IBrandRepository _brandRepository;
		private readonly IUserManager _userManager;

		public UpdateBrandCommandHandler(IBrandRepository brandRepository, IUserManager userManager)
		{
			_brandRepository = brandRepository;
			_userManager = userManager;
		}

		public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
		{
			var userId= _userManager.GetCurrentUserId();
			var brand = await _brandRepository.GetAsync(x => x.Id == request.Id);

			if (brand is null)
				throw new NotFoundException("Brand not found");

			brand.SetDetails(request.Name);

			brand.SetEditFields(userId);

			await _brandRepository.Update(brand);
			await _brandRepository.Commit();

			return true;
		}
	}
}
