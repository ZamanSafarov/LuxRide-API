using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Contact.Create
{
	public class CreateContactCommand:IRequest<bool>
	{
		public string Name { get;  set; }
		public string Email { get;  set; }

		public string Subject { get;  set; }
		public string Message { get;  set; }
	}
}
