using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Contacts
{
	public class Contact:Editable<User>,IBaseEntity
	{
		public int	Id {  get; set; }
		public string Name { get; private set; }
		public string Email { get; private set; }

		public string Subject{ get; private set; }
		public string Message{ get;private set; }



		public void SetDetails(string name,string email,string subject , string message)
		{
			Name = name;
			Email = email;
			Subject = subject;
			Message = message;
		}
	}
}
