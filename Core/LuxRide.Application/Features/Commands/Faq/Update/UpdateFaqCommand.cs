﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Faq.Create
{
	public class UpdateFaqCommand : IRequest<bool>
	{
		public int Id { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
	}
}
