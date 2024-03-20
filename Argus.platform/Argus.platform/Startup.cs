using Argus.Platform.Infrastructure.Middleware;
using Argus.Platform.Infrastructure.Services;
using Argus.Platform.Installers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Argus.Platform
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // get all Installer Instance that implment IInstaller Interface
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            // register All Installers
            installers.ForEach(x => x.InstallService(services, Configuration));

            // Register service that implment IScopedService,ITransientServices 
            services.AddServices();

           
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
          

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });






        }
    }
}
