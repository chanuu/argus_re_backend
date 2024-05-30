using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Companies
{
    public class Branch : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public static Branch Create(string address, string name, Guid tenantId, string email, string contactNo, Guid companyId)
        {
            Branch branch = new Branch()
            {
                TenantId = tenantId,
                Name = name,
                Email = email,
                ContactNo = contactNo,
                Address = address,
                CompanyId = companyId
            };

            return branch;

        }
    }
}
