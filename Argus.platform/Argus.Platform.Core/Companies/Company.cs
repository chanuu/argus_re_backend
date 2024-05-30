using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Companies
{
    public class Company : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string LogoUrl { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public List<Branch> Branch { get; set; }
        public static Company Create(string logoUrl, string name, Guid tenantId, string email, string contactNo)
        {
            Company company = new Company()
            {
                TenantId = tenantId,
                Name = name,
                Email = email,
                ContactNo = contactNo,
                LogoUrl = logoUrl                              
            };

            return company;

        }

    }
}
