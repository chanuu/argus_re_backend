using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Jobs
{
    public class JobType : BaseEntity
    {
        public string Reark { get; set; }
        public string Name { get; set; }
        public List<Job> Job { get; set; }


    }
}
