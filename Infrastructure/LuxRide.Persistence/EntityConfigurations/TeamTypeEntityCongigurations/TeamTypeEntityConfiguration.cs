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
	public class TeamTypeEntityConfiguration : IEntityTypeConfiguration<Team>
	{
		public void Configure(EntityTypeBuilder<Team> builder)
		{

			builder.ToTable("teams");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id)
				   .HasColumnName("id");


			builder.Property(t => t.Name)
			.IsRequired()
			.HasMaxLength(100)
				   .HasColumnName("name");


			builder.Property(t => t.Phone)
				.IsRequired()
				.HasMaxLength(20)
				  .HasColumnName("phone");


			builder.Property(t => t.Email)
				.IsRequired()
				.HasMaxLength(100)
				   .HasColumnName("email");


			builder.Property(t => t.Path)
				.IsRequired()
				   .HasColumnName("path");



			builder.HasMany(t => t.Experiences)
			.WithOne()
			.HasForeignKey(e => e.TeamId);
		}
	}
}
