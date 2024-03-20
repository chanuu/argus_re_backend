using Argus.Platform;
using Argus.Platform.Config;


public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args)
            .Build()
            .ConnectToDatabase(5, TimeSpan.FromSeconds(5))
            .MigrateDatabase()
            .SeedData()
            .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
           
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}
