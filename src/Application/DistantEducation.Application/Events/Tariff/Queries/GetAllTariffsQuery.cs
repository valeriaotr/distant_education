using DistantEducation.Application.Models.Tariff;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Queries;

public class GetAllTariffsQuery : IRequest<List<TariffModel>>
{
    public GetAllTariffsQuery() { }
}