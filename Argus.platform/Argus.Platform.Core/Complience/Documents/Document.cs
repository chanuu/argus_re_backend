using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Documents
{
    public class Document : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid TenantId { get; set; }

        public string AccessLevel { get; set; }
       
        public int ValidPeriod { get; set; }
        public string Description { get; set; }
        public DateTime? IssueDate { get; set; }
       
        public int AlertBefore { get; set; }

        public bool IsExpired { get; set; }

        public string Status { get; set; }

        [ForeignKey("DocumentTypeId")]
        public Document Documents { get; set; }
        public Guid DocumentTypeId { get; set; }

        public static Document Create(string code,string name,Guid TenantId ,string accessLevel,
            int validPeriod,DateTime? issueDate, int alertBefore,bool isExpired,string status)
        {

            if (code is null)
                throw new Exception("Document Code Cannot Be Null ");
            else if (accessLevel is null)
                throw new Exception("Access Level Cannot Be Null");
            else if (validPeriod <= 0)
                throw new Exception("Valid Period Must Be Positive value and Grater Then Zeoro");

            Document document = new Document() 
            {
                AccessLevel = accessLevel,
                Code = code, Name = name, 
                TenantId = TenantId,
                AlertBefore = alertBefore,
                IsExpired = isExpired,
                Status = status
            };

            return document;

        }
    }
}
