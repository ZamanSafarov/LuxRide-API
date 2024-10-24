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
	public class FleetImageEntityConfiguration : IEntityTypeConfiguration<FleetImage>
	{
		public void Configure(EntityTypeBuilder<FleetImage> builder)
		{
			builder.ToTable("fleetimage");
			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id).HasColumnName("id");
			builder.Property(t => t.Path).HasColumnName("path").IsRequired().HasMaxLength(500);
			builder.Property(t => t.IsMain).HasColumnName("ismain");

			builder.HasOne(f => f.Fleet)
				  .WithMany(f => f.FleetImages)
				  .HasForeignKey(f => f.FleetId)
				  .OnDelete(DeleteBehavior.Cascade);
		}
	}

}
