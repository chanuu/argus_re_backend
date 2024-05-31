using System.ComponentModel.DataAnnotations.Schema;

namespace Argus.Platform.Controllers.v1.Workflows.Dtos
{
    public record WorkItemDto(Guid TenantId,
                            string Event,
                            int OffSset,
                            Guid UserId
        );
    
}
