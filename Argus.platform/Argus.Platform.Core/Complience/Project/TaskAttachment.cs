using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Project
{
    public class TaskAttachment : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        [ForeignKey("TaskMasterId")]
        public ProjectTask ProjectTasks { get; set; }

        public Guid ProjectTaskId { get; set; }
    }
}
