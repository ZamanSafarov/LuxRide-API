using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Class.Create
{
	public class UpdateClassCommand : IRequest<bool>
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
