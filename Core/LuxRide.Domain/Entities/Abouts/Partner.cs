using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Abouts
{
	public class Partner:Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public string Name { get; private set; }
		public string Path { get; private set; }




		public void SetDetails(string name,string path)
		{
			Name = name;
			Path = path;
		}
	}
}
