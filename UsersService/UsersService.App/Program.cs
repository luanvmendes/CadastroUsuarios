using Microsoft.AspNetCore;

namespace UsersService.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            CreateWebHostBuilder(configuration, args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(IConfiguration configuration, string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                .UseStartup<Startup>();
        }
    }
}
