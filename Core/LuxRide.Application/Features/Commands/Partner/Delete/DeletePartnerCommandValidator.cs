using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Partner.Delete
{
	public class DeletePartnerCommandValidator : AbstractValidator<DeletePartnerCommand>
	{
		public DeletePartnerCommandValidator():base()
		{
			RuleFor(x => x.Id).NotNull();
		}
	}
}
