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
	public class FleetEntityConfiguration : IEntityTypeConfiguration<Fleet>
	{
		public void Configure(EntityTypeBuilder<Fleet> builder)
		{
			builder.ToTable("fleet");
			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id).HasColumnName("id");
			builder.Property(t => t.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
			builder.Property(t => t.PassangerCapacity).HasColumnName("passangercapacity").IsRequired();
			builder.Property(t => t.IsAvailable).HasColumnName("isavailable").HasDefaultValue(false);
			builder.Property(t => t.HourlyRate).HasColumnName("hourlyrate").HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(t => t.DailyRate).HasColumnName("dailyrate").HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(t => t.AirportTransferRate).HasColumnName("airporttransferrate").HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(t => t.BrandId).HasColumnName("brandid").IsRequired();
			builder.Property(t => t.ClassId).HasColumnName("classid").IsRequired();

			builder.HasOne(t => t.Brand)
				   .WithMany(b => b.Fleets)
				   .HasForeignKey(t => t.BrandId)
				   .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(t => t.Class)
				   .WithMany(c => c.Fleets)
				   .HasForeignKey(t => t.ClassId)
				   .OnDelete(DeleteBehavior.Restrict);
		}
	}

}
