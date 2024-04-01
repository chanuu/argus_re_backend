using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Documents
{
    public class DocumentReview : BaseEntity
    {
        public Guid ReviewBy { get; set; }

        public Guid DocumentId { get; set; }

        public DateTime? ReviewAt { get; set; }

        public string Comment { get; set; }


    }
}
