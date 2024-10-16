using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Abouts
{
	public class Faq:Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public string Question { get;private set; }
		public string Answer { get; private set; }

		public void SetDetails(string question, string answer)
		{
			 Question = question;
			Answer = answer;
		}

	}
}
