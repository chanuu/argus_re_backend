namespace Argus.Platform.Controllers.v1.Audits.DTOs
{
    public class AuditListDto
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }
    }
}
