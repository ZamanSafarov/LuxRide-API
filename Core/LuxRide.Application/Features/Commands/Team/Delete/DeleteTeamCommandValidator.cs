using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Team.Delete
{
	public class DeleteTeamCommandValidator:AbstractValidator<DeleteTeamCommand>
	{
		public DeleteTeamCommandValidator():base()
		{
			RuleFor(x => x.Id).NotNull();
		}
	}
}
