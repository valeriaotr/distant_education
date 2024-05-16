using DistantEducation.Application.Models.Tariff;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Queries;

public class GetTariffInfoQuery : IRequest<TariffModel>
{
    public string TariffId { get; set; }

    public GetTariffInfoQuery(string tariffId)
    {
        TariffId = tariffId;
    }
}