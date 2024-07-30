using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Middleware
{
    public interface IBranchProvider
    {
        Guid? GetBranchId();
    }
    public class BranchProvider : IBranchProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BranchProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? GetBranchId()
        {
            var branchId = _httpContextAccessor.HttpContext?.Items["BranchId"];
            if (branchId == null)
            {
                //throw new Exception("Tenant ID is not available.");
                return null;
            }

            return (Guid)branchId;
        }
    }
}
