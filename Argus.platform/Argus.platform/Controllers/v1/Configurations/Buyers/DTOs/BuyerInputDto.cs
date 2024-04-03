namespace Argus.Platform.Controllers.v1.Configurations.Buyers.DTOs
{
    public record BuyerInputDto(string Name,String Email,string Address);

    public record BuyerDetailDto(Guid Id, string Name, String Email, string Address);

    public record BuyerListDto(Guid Id, string Name, String Email, string Address);

    public record BuyerUpdateDto(string Name, String Email, string Address);

}
