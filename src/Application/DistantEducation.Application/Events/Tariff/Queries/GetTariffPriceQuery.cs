using MediatR;

namespace DistantEducation.Application.Events.Tariff.Queries;

public class GetTariffPriceQuery : IRequest<int>
{
    public string TariffId { get; set; }

    public GetTariffPriceQuery(string tariffId)
    {
        TariffId = tariffId;
    }
}