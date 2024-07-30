using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Middleware
{
    public interface ITenantProvider
    {
        Guid? GetTenantId();
    }

    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? GetTenantId()
        {
            var tenantId = _httpContextAccessor.HttpContext?.Items["TenantId"];
            if (tenantId == null)
            {
                //throw new Exception("Tenant ID is not available.");
                return null;
            }

            return (Guid)tenantId;
        }
    }
}
