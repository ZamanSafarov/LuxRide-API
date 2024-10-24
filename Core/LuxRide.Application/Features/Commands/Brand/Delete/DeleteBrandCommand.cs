using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Brand.Create
{
	public class DeleteBrandCommand:IRequest<bool>
	{
		public int Id { get; set; }
	}
}
