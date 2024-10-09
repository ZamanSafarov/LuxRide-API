using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxRide.Domain.Entities;

namespace LuxRide.Persistence.EntityConfigurations.UserTypeEntityConfigurations
{
	public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("users");
			builder.HasKey(t => t.Id);

			builder.Property(x => x.Id)
				   .HasColumnName("id");

			builder.Property(x => x.FirstName)
				   .IsRequired()
				   .HasColumnName("firstName");

			builder.Property(x => x.LastName)
				   .IsRequired()
				   .HasColumnName("lastName");

			builder.Property(x => x.UserName)
				 .IsRequired()
				 .HasColumnName("userName");


			builder.HasIndex(x => x.UserName)
				.IsUnique();

			builder.Property(x => x.Email)
				 .IsRequired()
				 .HasColumnName("mail");

			builder.Property(x => x.PasswordHash)
				 .IsRequired()
				 .HasColumnName("password_hash");

			builder.Property(x => x.PasswordHash)
				 .IsRequired()
				 .HasColumnName("password_hash");

			builder.Property(x => x.RefreshToken)
				 .HasColumnName("refresh_token");

			builder.Property(x => x.OTP)
			.HasColumnName("otp");

			builder.Property(x => x.Activated)
				 .HasColumnName("activated");

			builder.Property(x => x.IsDeleted)
				 .HasColumnName("isDeleted");

			builder.Property(x => x.LastPasswordChangeDateTime)
				 .HasColumnName("last_password_change_date");
		}
	}
}
