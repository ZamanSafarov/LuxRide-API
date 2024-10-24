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
	public class FleetAvailabilityEntityConfiguration : IEntityTypeConfiguration<FleetAvailability>
	{
		public void Configure(EntityTypeBuilder<FleetAvailability> builder)
		{
			builder.ToTable("fleetavailability");
			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id).HasColumnName("id");
			builder.Property(t => t.Date).HasColumnName("date").IsRequired().HasColumnType("date");
			builder.Property(t => t.IsAvailable).HasColumnName("isavailable").HasDefaultValue(true);

			builder.HasOne(f => f.Fleet)
				   .WithMany(f => f.FleetAvailabilities)
				   .HasForeignKey(fa => fa.FleetId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(t => t.AvailableTimeSlots)
				   .WithOne()
				   .HasForeignKey("fleetavailabilityid")
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}

}
