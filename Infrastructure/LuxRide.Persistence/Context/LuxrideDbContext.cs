using LuxRide.Domain.Entities;
using LuxRide.Domain.Entities.Abouts;
using LuxRide.Domain.Entities.Contacts;
using LuxRide.Domain.Entities.Fleets;
using LuxRide.Domain.Entities.Teams;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence.Context
{
	public class LuxrideDbContext:DbContext
	{
        public LuxrideDbContext(DbContextOptions options):base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Experience > Experiences { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Contact> Contacts{ get; set; }
		public DbSet<Faq> FAQs{ get; set; }
		public DbSet<About> Abouts{ get; set; }
		public DbSet<Partner> Partners{ get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Fleet> Fleets { get; set; }
		public DbSet<FleetImage> FleetImages { get; set; }
		public DbSet<FleetAvailability> FleetAvailabilities { get; set; }
		public DbSet<TimeSlot> TimeSlots { get; set; }
		public DbSet<Class> Classes { get; set; }
		public DbSet<Brand> Brands { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(LuxrideDbContext).Assembly);
		}
	}
}
