﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Team.DTOs
{
	public class ExperienceDtoUpdate
	{
		public int Id { get; set; }
		public string JobTitle { get; set; }
		public string JobDescription { get; set; }
		public string CompanyName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public bool IsPresent { get; set; }
	}
}
