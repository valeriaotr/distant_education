using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Tariff.Queries;
using DistantEducation.Application.Models.Tariff;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Handlers.QueryHandlers;

public class GetAllTariffsQueryHandler : IRequestHandler<GetAllTariffsQuery, List<TariffModel>>
{
    private readonly ITariffRepository _tariffRepository;

    public GetAllTariffsQueryHandler(ITariffRepository tariffRepository)
    {
        _tariffRepository = tariffRepository;
    }
    
    public async Task<List<TariffModel>> Handle(GetAllTariffsQuery request, CancellationToken cancellationToken)
    {
        return await _tariffRepository.FindAllTariffs();
    }
}