using LuxRide.Domain.Entities.Abouts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.EntityConfigurations.AboutTypeEntityConfigurations
{
	public class PartnerTypeEntityConfiguration : IEntityTypeConfiguration<Partner>
	{
		public void Configure(EntityTypeBuilder<Partner> builder)
		{
			builder.ToTable("partners");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id)
				   .HasColumnName("id");


			builder.Property(t => t.Name)
			.IsRequired()
			.HasMaxLength(150)
				   .HasColumnName("company-name");



			builder.Property(t => t.Path)
		.IsRequired()
		  .HasColumnName("path");
		}
	}
}
