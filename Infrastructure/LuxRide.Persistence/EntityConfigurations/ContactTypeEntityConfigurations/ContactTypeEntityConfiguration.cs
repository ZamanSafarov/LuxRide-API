using LuxRide.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.EntityConfigurations.ContactTypeEntityConfigurations
{
	public class ContactTypeEntityConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.ToTable("contacts");
			builder.HasKey(t => t.Id);

			builder.Property(x => x.Id)
				   .HasColumnName("id");

			builder.Property(x => x.Name)
				   .IsRequired()
				   .HasColumnName("name");

			builder.Property(x => x.Email)
				   .IsRequired()
				   .HasColumnName("mail");

			builder.Property(x => x.Subject)
				 .IsRequired()
				 .HasColumnName("subject");

			builder.Property(x => x.Message)
				.HasMaxLength(1000)
				 .IsRequired()
				 .HasColumnName("message");

		}
	}
}
