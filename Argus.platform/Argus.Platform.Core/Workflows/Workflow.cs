using Amazon.Lambda.Model;
using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Workflows
{
    public class Workflow : BaseEntity
    {
        public string Name { get; set; }
        public string Remark { get; set; }
        public bool IsHaveDueDate { get; set; }
        public Guid TenantId { get; set; }

        public static Workflow Create(string remark, string name, Guid tenantId, bool isHaveDueDate)
        {
            Workflow workflow = new Workflow()
            {
                TenantId = tenantId,
                Name = name,
                IsHaveDueDate = isHaveDueDate
            };

            return workflow;
        }
    }
}