using LuxRide.Application.Features.Commands.Team.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Review.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public int Rate { get; set; }
		public string Content { get; set; }
		public DateTime RecordDateTime { get; set; }
        public string Path { get; set; }
    }
}
