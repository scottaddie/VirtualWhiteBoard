using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using VirtualWhiteBoard3.Extensions;

namespace VirtualWhiteBoard3
{
    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                    config.ConfigureKeyVault())
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>());
    }
}
