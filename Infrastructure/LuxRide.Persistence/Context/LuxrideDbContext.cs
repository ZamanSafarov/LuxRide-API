using LuxRide.Domain.Entities;
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
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(LuxrideDbContext).Assembly);
		}
	}
}
