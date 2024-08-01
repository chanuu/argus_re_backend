using System.ComponentModel.DataAnnotations.Schema;

namespace Argus.Platform.Controllers.v1.Packages.Dtos
{
    public record PackageDto(
                             Guid Id,
                             string Name,
                             string Discription,
                             double Price,
                             string CoverImage
                            );
   
}
