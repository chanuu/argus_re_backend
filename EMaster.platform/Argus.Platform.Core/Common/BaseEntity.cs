using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Common
{
   public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public string DeletedBy { get; set; } = string.Empty;

        public string LastUpdatedBy { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public Guid RecordSignature { get; set; }
    }
}
