﻿using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Project
{
    public class TaskComments : BaseEntity
    {
        public Guid TenantId { get; set; }

        public string Comment { get; set; }

        public int CommentBy { get; set; }

        public DateTime? CommentAt { get; set; }

        public Guid Tagged { get; set; }

        [ForeignKey("ProjectTaskId")]
        public ProjectTask ProjectTasks { get; set; }

        public Guid ProjectTaskId { get; set; }
    }
}
