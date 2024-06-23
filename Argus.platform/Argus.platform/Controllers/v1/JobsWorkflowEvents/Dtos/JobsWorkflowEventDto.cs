using Argus.Platform.Core.JobsWorkflowEvents;
using System.ComponentModel.DataAnnotations.Schema;

namespace Argus.Platform.Controllers.v1.JobsWorkflowEvents.Dtos
{
    public record JobsWorkflowEventDto( string Event,
                                        DateTime DueDate,
                                        JobsWorkflowEventStatus status,   
                                        Guid JobId,    
                                        string UserId 
        
        );
   
}
