using Microsoft.OpenApi.Models;

namespace API
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();
			 
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cleanio API", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(builder => builder.AllowAnyOrigin());

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

