namespace DistantEducation.Application.Models.Dto.Tariff.UpdateTariffInfo;

public class UpdateTariffPriceRequestDto
{
    public string TariffId { get; set; }
    public int NewPrice { get; set; }

    public UpdateTariffPriceRequestDto(string tariffId, int newPrice)
    {
        TariffId = tariffId;
        NewPrice = newPrice;
    }
}