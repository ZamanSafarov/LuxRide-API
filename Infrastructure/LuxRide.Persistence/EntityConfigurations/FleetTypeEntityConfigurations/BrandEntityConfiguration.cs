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
	public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
	{
		public void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.ToTable("brand");
			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id).HasColumnName("id");
			builder.Property(t => t.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
		}
	}
}
