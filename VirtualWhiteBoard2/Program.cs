using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using VirtualWhiteBoard.Extensions;

namespace VirtualWhiteBoard
{
    public class Program
    {
        public static void Main(string[] args) =>
            CreateWebHostBuilder(args).Build().Run();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureAppConfiguration(config =>
                       config.ConfigureKeyVault())
                   .UseStartup<Startup>();
    }
}
