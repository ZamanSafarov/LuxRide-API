using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Class.Create
{
	public class DeleteClassCommand:IRequest<bool>
	{
		public int Id { get; set; }
	}
}
