using MediatR;

namespace DistantEducation.Application.Events.Tariff.Commands;

public class UpdateTariffPriceCommand : IRequest
{
    public string TariffId { get; set; }
    public int Price { get; set; }

    public UpdateTariffPriceCommand(string tariffId, int price)
    {
        TariffId = tariffId;
        Price = price;
    }
}