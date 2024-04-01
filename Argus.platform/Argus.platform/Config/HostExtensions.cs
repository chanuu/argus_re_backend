using Argus.Platform.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;

namespace Argus.Platform.Config
{
    public static class HostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var configuration = services.GetService<IConfiguration>();

                if (configuration.GetValue<bool>("Database:Seed"))
                {

                    Console.WriteLine("Database seeded");
                }
            }

            return host;
        }

        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<ApiContext>();
               // context.Database.Migrate();
            }

            return host;
        }

        public static IHost ConnectToDatabase(this IHost host, int maxRetryCount, TimeSpan retryDelay)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetService<ApiContext>();
                    var connected = false;
                    var retries = 0;
                    while (!connected)
                    {
                        try
                        {
                            context.Database.CanConnect();
                            connected = true;
                        }
                        catch (Exception)
                        {
                            retries++;
                            if (retries > maxRetryCount)
                            {
                                throw;
                            }

                            Task.Delay(retryDelay).Wait();
                        }
                    }
                }

                return host;
            }
        }
    }
}
