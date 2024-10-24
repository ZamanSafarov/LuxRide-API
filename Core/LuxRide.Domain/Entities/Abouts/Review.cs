using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Abouts
{
	public class Review : Editable<User>, IBaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public int Rate { get; set; }
		public string Content { get; set; }
		public string Path { get; set; }

		public void SetDetails(string name,string position,int rate,string content,string path) 
		{
			Name = name;
			Position = position;
			Rate = rate;
			Content = content;
			Path = path;
		}
	}
}
