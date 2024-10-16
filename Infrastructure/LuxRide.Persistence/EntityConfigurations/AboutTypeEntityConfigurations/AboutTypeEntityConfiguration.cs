using FluentValidation;
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
	public class AboutTypeEntityConfiguration : IEntityTypeConfiguration<About>
	{
		public void Configure(EntityTypeBuilder<About> builder)
		{
			builder.ToTable("about");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id)
				   .HasColumnName("id");


			builder.Property(t => t.Title)
			.IsRequired()
			.HasMaxLength(300)
				   .HasColumnName("title");


			builder.Property(t => t.Description)
				.IsRequired()
				  .HasColumnName("description");

			builder.Property(t => t.Path)
		.IsRequired()
		  .HasColumnName("path");
		}
	}
}
