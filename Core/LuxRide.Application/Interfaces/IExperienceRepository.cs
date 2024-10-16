﻿using LuxRide.Domain.Entities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Interfaces
{
	public interface IExperienceRepository:IRepository<Experience>
	{

		public  Task RemoveRange(IEnumerable<Experience> experiences);
	}
}
