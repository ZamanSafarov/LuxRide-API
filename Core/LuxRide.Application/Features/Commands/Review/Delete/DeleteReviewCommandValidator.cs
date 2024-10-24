using FluentValidation;
using LuxRide.Application.Features.Commands.Review.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Review.Delete
{
	public class DeleteReviewCommandValidator: AbstractValidator<DeleteReviewCommand>
	{

        public DeleteReviewCommandValidator():base()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
