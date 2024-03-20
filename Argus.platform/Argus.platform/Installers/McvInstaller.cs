
using Argus.Platform.Infrastructure.Config;
using Argus.Platform.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Argus.Platform.Installers
{
    public class McvInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setup =>
            {
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                setup.OperationFilter<AddHeaderParameter>();

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { jwtSecurityScheme, Array.Empty<string>() }
                    });


            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {

                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // Replace with your React UI's URL
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

        }
    }
}
