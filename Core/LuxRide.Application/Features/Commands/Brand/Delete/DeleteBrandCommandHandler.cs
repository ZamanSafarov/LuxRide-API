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
	public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, bool>
	{
		private readonly IBrandRepository _brandRepository;

		public DeleteBrandCommandHandler( IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
		{
			var brand = await _brandRepository.GetAsync(x => x.Id == request.Id);

			if (brand is null)
				throw new NotFoundException("Brand not found");

			await _brandRepository.HardDeleteAsync(brand);
			await _brandRepository.Commit();

			return true;
		}
	}
}
