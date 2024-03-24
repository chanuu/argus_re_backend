using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Project
{
    public class ProjectTask : BaseEntity
    {
        public int CategoryID { get; set; }

        public DateTime? DueDate { get; set; }

        public Guid HandleByID { get; set; }

        public Guid OwnerId { get; set; }

        public DateTime? CompletedDate { get; set; }

        public string Importance { get; set; }

        public TaskStatus Status { get; set; }


        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public Guid ProjectId { get; set; }

        public virtual ICollection<TaskAttachment> TaskAttachments { get; set; }

    }
}
