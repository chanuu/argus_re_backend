namespace Argus.Platform.Controllers.v1.JobEvents.Dtos
{
    public record JobEventDto(Guid TenantId,
                            string StartingTime,
                            string EndTime,
                            string Name,
                            string Lcation,
                            bool IsAlreadyEvent,
                            bool IsMainEvent,
                            DateOnly Date
        );
   
    
}
