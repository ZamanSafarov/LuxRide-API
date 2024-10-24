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
	public class ReviewTypeEntityConfiguration:IEntityTypeConfiguration<Review>
	{
	

		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.ToTable("reviews");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id)
				   .HasColumnName("id");


			builder.Property(t => t.Name)
				.IsRequired()
				.HasColumnName("name");

			builder.Property(t => t.Position)
			.IsRequired()
			.HasColumnName("position");

			builder.Property(t => t.Content)
					.IsRequired()
					  .HasColumnName("content");

			builder.Property(t => t.Rate)
				.IsRequired()
				.HasMaxLength(1)
				.HasColumnName("rate");

			builder.Property(t => t.Path)
			.IsRequired()
			  .HasColumnName("path");
		}
	}
}
