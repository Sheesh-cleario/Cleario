using API.Helpers;
using API.Middleware;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

namespace API
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfiles));
			services.AddSingleton<IOrderPriceService, OrderPriceService>();
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddCors();

			services.AddDbContext<CleaningContext>(x => x.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cleario API", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseMiddleware<ExceptionMiddleware>();

			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"));
			}

			app.UseHttpsRedirection();
			
			app.UseRouting();
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(
					Path.Combine(Directory.GetCurrentDirectory(), "FileStorage")
				),
				RequestPath = "/MessageFiles"
			});

			app.UseCors(builder => builder.AllowAnyOrigin());

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

