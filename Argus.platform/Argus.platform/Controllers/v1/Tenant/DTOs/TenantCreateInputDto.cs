namespace Argus.Platform.Controllers.v1.Tenant.DTOs
{
    public class TenantCreateInputDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Email { get; set; }

        public string ConnetionString { get; set; }

        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }

        public string BrachName { get; set; }

        public string BrachEmail { get; set; }

        public string UserName { get; set; }

        public string AdminEmailAddress { get; set; }

        public string AdminPassword { get; set; }


    }
}
