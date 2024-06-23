using Argus.Platform.Core.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Argus.Platform.Controllers.v1.Customers.Dtos
{
    public record CustomerDto(string Name,
                              string Email,
                              string Note,
                              string ContactNo,
                              Guid TenantId,
                              Status Status,
                              Guid BranchId
    );

}
