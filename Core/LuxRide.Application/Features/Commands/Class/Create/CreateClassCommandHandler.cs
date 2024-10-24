using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Class.Create
{
	public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, bool>
	{
		private readonly IClassRepository _classRepository;
		private readonly IUserManager _userManager;

		public CreateClassCommandHandler(IUserManager userManager, IClassRepository classRepository)
		{
			_userManager = userManager;
			_classRepository = classRepository;
		}

		public async Task<bool> Handle(CreateClassCommand request, CancellationToken cancellationToken)
		{
			var userId = _userManager.GetCurrentUserId();

			var clas = new Domain.Entities.Fleets.Class();

			clas.SetDetails(request.Name);

			clas.SetAuditDetails(userId);

			await _classRepository.AddAsync(clas);
			await _classRepository.Commit();

			return true;
		}
	}
}
