using System.Threading.Tasks;
using apiplate.StartupTasks.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
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
                      var webRootPath = Environment.GetEnvironmentVariable("ASPNETCORE_WEBROOT");
                
                // Set the custom web root path
                webBuilder.UseWebRoot(webRootPath);
                    webBuilder.UseStartup<Startup>();
                    
                });
    }
}
