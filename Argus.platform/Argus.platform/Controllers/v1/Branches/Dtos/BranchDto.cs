namespace Argus.Platform.Controllers.v1.Branches.Dtos
{
    public record BranchDto
    (                        string Name,
                             string Email,
                             string Address,
                             string ContactNo,
                             Guid TenantId,
                             Guid CompanyId
                             );
}
