using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Teams
{
	public class Team : Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public string Name { get; private set; }
		public string Phone { get; private set; }
		public string Email { get; private set; }
		public string Path { get; private set; }

		public List<Experience> Experiences { get; private set; }
        public Team()
        {
			Experiences = new List<Experience>();
        }

        public void SetDetails(string name, string phone,string email,string path)
		{
			Name = name;
			Phone = phone;
			Email = email;
			Path = path;
		}
	}
}
