
using Argus.Platform.Infrastructure;
using Argus.Platform.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

namespace Argus.Platform.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database:ConnectionString");
            services.AddApiContext(
              configuration["Database:ConnectionString"],
              typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
        }
    }
}
