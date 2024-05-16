namespace DistantEducation.Application.Models.Dto.Tariff.CreateNewTariff;

public class CreateTariffRequestDto
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Validity { get; set; }

    public CreateTariffRequestDto(string name, int price, int validity)
    {
        Name = name;
        Price = price;
        Validity = validity;
    }
}