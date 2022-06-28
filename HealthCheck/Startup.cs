using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
            AppConfig.Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

			services.AddControllers();
        }

		public void Configure(IApplicationBuilder app)
		{
			app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}