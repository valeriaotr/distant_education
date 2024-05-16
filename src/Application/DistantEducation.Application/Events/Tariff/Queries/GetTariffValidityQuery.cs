using MediatR;

namespace DistantEducation.Application.Events.Tariff.Queries;

public class GetTariffValidityQuery : IRequest<int>
{
    public string TariffId { get; set; }

    public GetTariffValidityQuery(string tariffId)
    {
        TariffId = tariffId;
    }
}