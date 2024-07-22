using System.ComponentModel.DataAnnotations.Schema;

namespace Argus.Platform.Controllers.v1.Features.DTOs
{
    public record FeatureDto(
                        string FeatureName,
                        string Limit,
                        string DiscriminatorMessage,
                        Guid SubscriptionId
        ); 
   
}
