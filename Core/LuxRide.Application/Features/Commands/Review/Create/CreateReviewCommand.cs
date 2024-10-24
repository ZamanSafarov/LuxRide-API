using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Review.Create
{
	public class CreateReviewCommand:IRequest<bool>
	{
		public string Name { get; set; }
		public string Position { get; set; }
		public int Rate { get; set; }
		public string Content { get; set; }
		public IFormFile Photo { get; set; }
	}
}
