using Argus.Platform.Core.Common;
using Argus.Platform.Core.Identity;
using Argus.Platform.Core.Jobs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.JobsWorkflowEvents
{
    public class JobsWorkflowEvent : BaseEntity
    {
        
        public string Event { get; set; }
        public DateTime DueDate { get; set; }
        public JobsWorkflowEventStatus status { get; set; }

        [ForeignKey("JobId")]
        public Job Job { get; set; }
        public Guid JobId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; }

    }
}





