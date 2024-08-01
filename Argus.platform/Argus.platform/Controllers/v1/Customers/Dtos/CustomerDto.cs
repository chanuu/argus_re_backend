using Argus.Platform.Core.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Argus.Platform.Controllers.v1.Customers.Dtos
{
    public record CustomerDto(
                              Guid Id,
                              string Name,
                              string Email,
                              string Note,
                              string ContactNo,                            
                              Status Status
                             
    );

}
