using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Abouts
{
	public class About:Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public string Path { get;private set; }
		public string Title { get;private set; }
		public string Description { get;private set; }


		public void SetDetails(string path,string title , string description)
		{
			Path = path;
			Title = title;
			Description = description;
		}

	}
}
