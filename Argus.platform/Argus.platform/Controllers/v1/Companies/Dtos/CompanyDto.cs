namespace Argus.Platform.Controllers.v1.Companies.Dtos
{
    
    public record CompanyDto(string Name,
                            string Email,
                             string LogoUrl,
                             string ContactNo,
                             Guid TenantId
    );
}
