namespace Argus.Platform.Controllers.v1.Files.DTOs
{
   // public record S3ObjectDto(string Name,string PresignedUrl);

    public class S3ObjectDto
    {
        public string Name { get; set; }

        public string PresignedUrl { get; set; }
    }
}
