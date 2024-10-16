using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Faq.DTOs
{
	public class FaqDto
	{
		public int Id { get; set; }
		public string Answer { get; set; }
		public string Question{ get; set; }
		public DateTime RecordDateTime { get; set; }
	}
}
