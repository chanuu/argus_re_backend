using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Middleware.DTOs
{
    public class Meta
    {
        public bool IsSucceeded { get; set; }
        public int HttpErrorCode { get; set; }
        public string Message { get; set; }
    }
}
