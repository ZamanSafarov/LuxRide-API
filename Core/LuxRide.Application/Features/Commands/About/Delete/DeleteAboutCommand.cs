using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.About.Delete
{
	public class DeleteAboutCommand:IRequest<bool>
	{
		public int Id { get; set; }	
	}
}
