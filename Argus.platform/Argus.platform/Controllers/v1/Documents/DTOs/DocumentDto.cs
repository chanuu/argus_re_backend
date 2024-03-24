namespace Argus.Platform.Controllers.v1.Documents.DTOs
{
    public record DocumentDto(
    string Code,
    string Name,
    Guid TenantId,
    string AccessLevel,
    int ValidPeriod,
    string Description,
    DateTime? IssueDate,
    int AlertBefore,
    bool IsExpired,
    string Status,
    Guid DocumentTypeId);


}
