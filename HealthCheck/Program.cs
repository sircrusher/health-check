using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HealthCheck
{
    class Program
    {
		static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseSystemd()
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    logging.AddSimpleConsole(options =>
                    {
                        options.IncludeScopes = true;
                        options.SingleLine = true;
                        options.TimestampFormat = "yyyy-MM-dd HH:mm:ss.ffffff ";
                    });
                })
                .ConfigureWebHost(builder => builder
                    .UseKestrel()
                    .UseUrls("http://*:80")
                    .UseConfiguration(new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build()
                    ).UseStartup<Startup>())
                .Build()
                .RunAsync();
        }
	}
}