using Microsoft.Extensions.Configuration;

namespace HealthCheck
{
	public static class AppConfig
	{
		public static IConfiguration Configuration { get; set; }
	}
}