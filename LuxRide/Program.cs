using LuxRide.Application;
using LuxRide.Persistence;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog.Events;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using LuxRide.Middleware;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.FileProviders;
using LuxRide.Infrastructure;
namespace LuxRide
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddPersistenceRegistration(builder.Configuration);
			builder.Services.AddAplicationRegistration();

			var environment = builder.Environment;

			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.Build();



			builder.Services.AddCors(option =>
			{
				option.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyOrigin()
					.AllowAnyHeader()
					.WithExposedHeaders("content-disposition", "Content-Disposition")
					);
			});
			builder.Services.AddMvc(opt =>
			{
				opt.MaxModelBindingCollectionSize = int.MaxValue;
			});
			builder.Services.Configure<KestrelServerOptions>(options =>
			{
				options.AddServerHeader = false;
				options.Limits.MaxRequestBodySize = int.MaxValue;
			});

			builder.Services.Configure<FormOptions>(x =>
			{
				x.ValueLengthLimit = int.MaxValue;
				x.MultipartBodyLengthLimit = int.MaxValue;
			});

			builder.Services.AddAuthentication(opt => {
				opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

			}).AddJwtBearer(opt =>
			{
				opt.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateAudience = false,
					ValidateIssuer = false,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:SecretKey").Value))
				};
			});

			builder.Services.AddAuthorization();
			var serilog = new LoggerConfiguration()
				.WriteTo.File(
				configuration["Serilog:WriteTo:1:Args:path"],
				rollingInterval: RollingInterval.Day,
				restrictedToMinimumLevel: LogEventLevel.Error)
				.CreateLogger();
			builder.Host.UseSerilog(serilog);


			builder.Services.AddSwaggerGen(c =>
			{
				var securityScheme = new OpenApiSecurityScheme
				{
					Name = "JWT Authentication",
					Description = "Enter your JWT token in this field",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					BearerFormat = "JWT"
				};

				c.AddSecurityDefinition("Bearer", securityScheme);

				var securityRequirement = new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new string[] {}
		}
	};

				c.AddSecurityRequirement(securityRequirement);
			});


			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddHttpContextAccessor();
			builder.Services.Configure<FileSettings>(configuration.GetSection(nameof(FileSettings)));


			var app = builder.Build();
			app.UseMiddleware<ExceptionHandlingMiddleware>();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseSwagger()
	.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnionArchitecture.API V1");
		c.DocumentTitle = "LuxRide API";
		c.DocExpansion(DocExpansion.List);
	});
			app.UseStaticFiles();
			app.UseSerilogRequestLogging();
			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseCors("CorsPolicy");

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			//using (var scope = app.Services.CreateScope())
			//{
			//	var services = scope.ServiceProvider;
			//	var context = services.GetRequiredService<TestDbContext>();
			//	var logger = services.GetRequiredService<ILogger<TestSeedDbContext>>();
			//	var seed = services.GetRequiredService<TestSeedDbContext>();
			//	await seed.SeedAsync(context, logger);
			//}
			if (environment.IsStaging())
			{
				app.UseFileServer(new FileServerOptions
				{
					FileProvider = new PhysicalFileProvider(configuration.GetSection("FileSettings:Path").Value),
					RequestPath = new PathString("/uploads")
				});
			}


			app.Run();
		}
	}
}
