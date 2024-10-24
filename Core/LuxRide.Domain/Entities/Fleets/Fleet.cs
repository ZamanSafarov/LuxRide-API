using LuxRide.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Domain.Entities.Fleets
{
	public class Fleet:Editable<User>,IBaseEntity
	{
		public int Id { get; set; }
		public string Name { get;private set; }
		public Brand Brand { get; set; }
		public int BrandId { get; private set; }
		public	Class Class { get; set; }
		public int ClassId { get;private set; }
		public int PassangerCapacity { get; private set; }
		public List<FleetImage> FleetImages { get; private set; }
		public bool IsAvailable { get; private set; }
		public decimal HourlyRate { get; private set; }
		public decimal DailyRate { get; private set; }
		public decimal AirportTransferRate { get; private set; }
		public List<FleetAvailability> FleetAvailabilities { get; private set; }


        public Fleet()
        {
            FleetImages = new List<FleetImage>();
			FleetAvailabilities= new List<FleetAvailability>();
		}

		public void SetDetails(string name,int passangerCapacity,bool available,decimal hourlyRate,decimal dailyRate,decimal airportTransferRate,int brandId,int classId)
		{
			Name = name;
			PassangerCapacity = passangerCapacity;
			HourlyRate = hourlyRate;
			DailyRate = dailyRate;
			AirportTransferRate = airportTransferRate;
			IsAvailable = available;
			BrandId = brandId;
			ClassId = classId;
		}
    }
}
