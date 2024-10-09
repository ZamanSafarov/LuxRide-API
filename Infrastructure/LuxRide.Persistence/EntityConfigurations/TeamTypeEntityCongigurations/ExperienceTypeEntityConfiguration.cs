using FluentValidation;
using LuxRide.Domain.Entities.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.EntityConfigurations.TeamTypeEntityCongigurations
{
	public class ExperienceTypeEntityConfiguration : IEntityTypeConfiguration<Experience>
	{
		public void Configure(EntityTypeBuilder<Experience> builder)
		{
			builder.ToTable("experiences");
			builder.HasKey(x=>x.Id);

			builder.Property(x => x.Id)
				   .HasColumnName("id");

			builder.Property(x => x.CompanyName)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnName("companyName");

			builder.Property(x => x.JobDescription)
				.IsRequired()
				 .HasMaxLength(500)
				.HasColumnName("jobDescription");

			builder.Property(x => x.JobTitle)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnName("jobTitle");

			builder.Property(x => x.CompanyName)
				.IsRequired()
				.HasColumnName("companyName");

			builder.Property(x => x.StartDate)
				.IsRequired()
				 .HasColumnName("start_date");

			builder.Property(x => x.EndDate)
				 .HasColumnName("end_date");

			builder.Property(x => x.IsPresent)
				.HasDefaultValue(false)
				 .HasColumnName("isPresent");

			builder.HasOne<Team>()
		   .WithMany(t => t.Experiences)
		   .HasForeignKey(e => e.TeamId);
		}
	}
}
