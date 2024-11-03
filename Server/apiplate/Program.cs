using System.IO;
using System.Threading.Tasks;
using apiplate.StartupTasks.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace apiplate
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunWithTasksAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                       var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // Get the WebRootPath value from appsettings.json
                var webRootPath = config.GetValue<string>("WebRootPath");

                // Set the custom web root path
                webBuilder.UseWebRoot(webRootPath);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
