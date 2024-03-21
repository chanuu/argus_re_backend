using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Documents
{
   public class DocumentType : BaseEntity
    {
        public string Name { get; set; }

        public List<Document> Documents { get; set; }

    }
}
