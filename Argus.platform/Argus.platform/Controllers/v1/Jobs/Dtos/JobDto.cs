using Argus.Platform.Core.Jobs;
using System.ComponentModel.DataAnnotations.Schema;

namespace Argus.Platform.Controllers.v1.Jobs.Dtos
{
    public record JobDto(string Name, 
                         Guid TenantId, 
                         string Note,
                         Core.Jobs.Type Type,   
                         Guid JobTypeId, 
                         Guid BranchId, 
                         Guid CustomerId,
                         Guid WorkflowId 
     );
   

}
