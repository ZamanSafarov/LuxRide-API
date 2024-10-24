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
	public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, bool>
	{
		private readonly IClassRepository _classRepository;

		public DeleteClassCommandHandler( IClassRepository classRepository)
		{
			_classRepository = classRepository;
		}

		public async Task<bool> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
		{
			var clas = await _classRepository.GetAsync(x => x.Id == request.Id);

			if (clas is null)
				throw new NotFoundException("Class not found");

			await _classRepository.HardDeleteAsync(clas);
			await _classRepository.Commit();

			return true;
		}
	}
}
