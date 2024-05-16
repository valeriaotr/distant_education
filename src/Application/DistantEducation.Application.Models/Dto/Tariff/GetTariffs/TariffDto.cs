namespace DistantEducation.Application.Models.Dto.Tariff.GetTariffs;

public class TariffDto
{
    public string TariffId { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public int Validity { get; set; }
}