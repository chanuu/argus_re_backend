using Argus.Platform.Core.Identity;
using Argus.Platform.Infrastructure.Middleware;
using Argus.Platform.Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApiContext(
           this IServiceCollection services,
           string connectionString,
           string migrationsAssemblyName)
        {
           

                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
               .AddScoped<ITenantProvider, TenantProvider>()
               .AddScoped<IBranchProvider, BranchProvider>();
                return services.AddDbContext<ApiContext>(options =>
                {

                    options.UseNpgsql(connectionString, npgsqlOptionsAction: npgsqlOptions =>
                    {
                        npgsqlOptions.MigrationsAssembly(migrationsAssemblyName);
                    });
                })
                .AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })

               .AddRoles<Role>()

               .AddEntityFrameworkStores<ApiContext>()

               .Services;
        }
    }
}
