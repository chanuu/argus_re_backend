using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Exclude token validation for specific paths like login and signup

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var tenantIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "tenantId");
                var branchIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "branchId");
                if (tenantIdClaim != null && branchIdClaim != null)
                {
                    context.Items["TenantId"] = Guid.Parse(tenantIdClaim.Value);
                    context.Items["BranchId"] = Guid.Parse(branchIdClaim.Value);
                }
            }

            await _next(context);
        }
    }
}
