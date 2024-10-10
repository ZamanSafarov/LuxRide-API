﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Common.Pagination
{
	public class PaginatedResult<T>
	{
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public int TotalCount { get; set; }
		public List<T> Data { get; set; }
	}
}
