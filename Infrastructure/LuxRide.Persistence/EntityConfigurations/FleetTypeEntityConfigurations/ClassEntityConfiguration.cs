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
	public class ClassEntityConfiguration : IEntityTypeConfiguration<Class>
	{
		public void Configure(EntityTypeBuilder<Class> builder)
		{
			builder.ToTable("class");
			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id).HasColumnName("id");
			builder.Property(t => t.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
		}
	}
}
