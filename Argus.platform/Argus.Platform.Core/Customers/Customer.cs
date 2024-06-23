using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Customers
{
    public class Customer: BaseEntity
    {
        public Guid TenantId { get; set; }
        public string Note{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Status Status { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public Guid BranchId { get; set; }
        public static Customer Create(string note, string name, Guid tenantId, string email, string contactNo, Status status, Guid branchId)
        {
            Customer customer = new Customer()
            {
                TenantId = tenantId,
                Name = name,
                Email = email,
                ContactNo = contactNo,
                Note = note,
                Status = status,
                BranchId = branchId
            };

            return customer;

        }
    }
}
