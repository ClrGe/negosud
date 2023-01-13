using Microsoft.AspNetCore;

namespace NegoSudApi;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                //webBuilder.UseUrls("httpS://localhost:4000");
                webBuilder.UseStartup<Startup>();
            });
}