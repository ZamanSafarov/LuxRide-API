using LuxRide.Application.Interfaces;
using LuxRide.Persistence.Concretes;
using LuxRide.Persistence.Context;
using LuxRide.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddDbContext<LuxrideDbContext>(opt =>
			{
				opt.UseNpgsql(configuration.GetConnectionString("cString"), options =>
				{
					options.MigrationsHistoryTable("__efmigrationshistory", "testing");
					options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(3), new List<string>());
				});
			});

			services.Scan(scan => scan
				.FromAssembliesOf(typeof(IRepository<>))
				.AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
				.AsImplementedInterfaces()
				.WithScopedLifetime());

			services.Scan(scan => scan
				.FromAssembliesOf(typeof(Repository<>))
				.AddClasses(classes => classes.AssignableTo(typeof(Repository<>)))
				.AsImplementedInterfaces()
				.WithScopedLifetime());



			services.AddScoped<IClaimManager, ClaimManager>();
			services.AddScoped<IUserManager, UserManager>();
			services.AddScoped<IEmailManager, EmailManager>();
		}
	}
}
