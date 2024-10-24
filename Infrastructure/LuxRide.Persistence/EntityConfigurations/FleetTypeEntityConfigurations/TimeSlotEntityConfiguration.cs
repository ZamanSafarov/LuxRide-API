using LuxRide.Domain.Entities.Fleets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.EntityConfigurations.FleetTypeEntityConfigurations
{
	public class TimeSlotEntityConfiguration : IEntityTypeConfiguration<TimeSlot>
	{
		public void Configure(EntityTypeBuilder<TimeSlot> builder)
		{
			builder.ToTable("timeslot");
			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id).HasColumnName("id");
			builder.Property(t => t.StartTime).HasColumnName("starttime").IsRequired();
			builder.Property(t => t.EndTime).HasColumnName("endtime").IsRequired();
			builder.Property(t => t.IsAvailable).HasColumnName("isavailable").HasDefaultValue(true);

		}
	}
}
