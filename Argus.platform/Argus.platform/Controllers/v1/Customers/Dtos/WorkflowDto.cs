namespace Argus.Platform.Controllers.v1.Customers.Dtos
{
    public record WorkflowDto(string Name,
                              string Remark,
                              bool IsHaveDueDate,
                              Guid TenantId);
   
}
