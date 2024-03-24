using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Project
{
    public class Project : BaseEntity
    {
        public Guid TenentId { get; set; }

        public string ProjectName { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public AccessLevel AccessLevel { get; set; }

        public int AccessGroupId { get; set; }

        public Guid OwnerID { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? StartedDate { get; set; }

        public string Status { get; set; }

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }

    }
}