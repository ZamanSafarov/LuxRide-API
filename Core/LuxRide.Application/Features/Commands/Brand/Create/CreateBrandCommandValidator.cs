using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Brand.Create
{
	public class CreateBrandCommandValidator:AbstractValidator<CreateBrandCommand>
	{
        public CreateBrandCommandValidator():base()
        {
			RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name is required.");
		}
    }
}
