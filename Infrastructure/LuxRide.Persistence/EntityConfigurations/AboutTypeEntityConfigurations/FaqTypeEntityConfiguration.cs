using LuxRide.Domain.Entities.Abouts;
using LuxRide.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.EntityConfigurations.AboutTypeEntityConfigurations
{
	public class FaqTypeEntityConfiguration:IEntityTypeConfiguration<Faq>
	{
		public void Configure(EntityTypeBuilder<Faq> builder)
		{
			builder.ToTable("faqs");
			builder.HasKey(t => t.Id);

			builder.Property(x => x.Id)
				   .HasColumnName("id");

			builder.Property(x => x.Question)
				   .IsRequired()
				   .HasColumnName("question");

			builder.Property(x => x.Answer)
				   .IsRequired()
				   .HasColumnName("answer");

		}
	}
}
