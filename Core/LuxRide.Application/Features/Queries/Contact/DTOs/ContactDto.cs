using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Contact.DTOs
{
	public class ContactDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public string Subject { get; set; }
		public string Message { get; set; }
		public DateTime RecordDateTime { get; set; }
	}
}
