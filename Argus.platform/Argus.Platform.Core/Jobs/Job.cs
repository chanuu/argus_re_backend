using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Documents;
using Argus.Platform.Core.Workflows;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Jobs
{
    public class Job : BaseEntity
    {        
        public string Name { get; set; }
        public Guid TenantId { get; set; }

        public string Note { get; set; }
        
        public Type  Type { get; set; }

        [ForeignKey("JobTypeId")]
        public JobType JobType { get; set; }
        public Guid JobTypeId { get; set; }

        public Guid BranchId { get; set; }
        public Guid CustomerId { get; set; }

        public Guid WorkflowId { get; set; }

        public static Job Create(string note, string name, Guid TenantId, Type type,
                                 Guid jobTypeId, Guid branchId, Guid customerId, Guid workflowId)
        {

            Job job = new Job()
            {
                Note = note,
                Name = name,
                TenantId = TenantId,
                Type = type,
                JobTypeId = jobTypeId,
                BranchId = branchId,
                CustomerId = customerId,
                WorkflowId = workflowId
             
            };

            return job;

        }

    }


}
