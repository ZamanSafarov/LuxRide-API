﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.About.Delete
{
	public class DeleteAboutCommandValidator : AbstractValidator<DeleteAboutCommand>
	{
		public DeleteAboutCommandValidator():base()
		{
			RuleFor(x => x.Id).NotNull();
		}
	}
}