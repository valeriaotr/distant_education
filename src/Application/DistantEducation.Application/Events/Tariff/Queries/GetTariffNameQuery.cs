using MediatR;

namespace DistantEducation.Application.Events.Tariff.Queries;

public class GetTariffNameQuery : IRequest<string>
{
    public string TariffId { get; set; }

    public GetTariffNameQuery(string tariffId)
    {
        TariffId = tariffId;
    }
}