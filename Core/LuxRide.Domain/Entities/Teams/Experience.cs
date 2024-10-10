using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Teams
{
	public class Experience : Editable<User>, IBaseEntity
	{
		public int Id { get; set; }
		public string JobTitle { get; private set; }
		public string JobDescription { get; private set; }
		public string CompanyName { get; private set; }
		public DateTime StartDate { get;private set; }
		public DateTime? EndDate { get;private set; }
		public int TeamId { get;  set; }
		public bool IsPresent { get; private set; }
		public void SetDetails(string jobTitle, string jobDescription, string companyName)
		{
			JobDescription = jobDescription;
			CompanyName = companyName;
			JobTitle = jobTitle;
		}
		public void SetExperienceDate(DateTime startDate, DateTime? endDate, bool isPresent =false)
		{
			StartDate = startDate.Kind == DateTimeKind.Utc ? startDate : startDate.ToUniversalTime();
			EndDate = endDate.HasValue ? (endDate.Value.Kind == DateTimeKind.Utc ? endDate.Value : endDate.Value.ToUniversalTime()) : (DateTime?)null;
			IsPresent = isPresent;
		}
	}
}
