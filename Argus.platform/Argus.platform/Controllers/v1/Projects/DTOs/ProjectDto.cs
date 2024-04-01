using Argus.Platform.Core.Common;

namespace Argus.Platform.Controllers.v1.Projects.DTOs
{
    public record ProjectDto(
    Guid TenantId,
    string ProjectName,
    string Category,
    string Description,
    AccessLevel AccessLevel,
    int AccessGroupId,
    Guid OwnerID,
    DateTime DueDate,
    DateTime? StartedDate,
    string Status);
}
