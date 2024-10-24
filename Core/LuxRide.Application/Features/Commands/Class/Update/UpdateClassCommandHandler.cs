using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Class.Create
{
	internal class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, bool>
	{
		private readonly IClassRepository _classRepository;
		private readonly IUserManager _userManager;

		public UpdateClassCommandHandler(IClassRepository classRepository, IUserManager userManager)
		{
			_classRepository = classRepository;
			_userManager = userManager;
		}

		public async Task<bool> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
		{
			var userId= _userManager.GetCurrentUserId();
			var clas = await _classRepository.GetAsync(x => x.Id == request.Id);

			if (clas is null)
				throw new NotFoundException("Class not found");

			clas.SetDetails(request.Name);

			clas.SetEditFields(userId);

			await _classRepository.Update(clas);
			await _classRepository.Commit();

			return true;
		}
	}
}
