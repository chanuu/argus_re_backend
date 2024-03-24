using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Documents
{
    public class DocumentRenewal  : BaseEntity
    {
        public int TenantId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string ScanCopy { get; set; }

        [ForeignKey("DocumentId")]
        public Document Document { get; set; }
        public Guid DocumentId { get; set; }

        public string Status { get; set; }


    }
}
