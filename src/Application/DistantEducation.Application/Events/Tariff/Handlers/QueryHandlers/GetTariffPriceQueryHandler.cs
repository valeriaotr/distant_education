using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Tariff.Queries;
using DistantEducation.Application.Exceptions.Tariff;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Handlers.QueryHandlers;

public class GetTariffPriceQueryHandler : IRequestHandler<GetTariffPriceQuery,int>
{
    private readonly ITariffRepository _tariffRepository;

    public GetTariffPriceQueryHandler(ITariffRepository tariffRepository)
    {
        _tariffRepository = tariffRepository;
    }
    
    public async Task<int> Handle(GetTariffPriceQuery request, CancellationToken cancellationToken)
    {
        var tariffModel = await _tariffRepository.FindTariffById(request.TariffId);
        if (tariffModel == null)
        {
            throw new NullTariffException($"Could not find tariff with ID {request.TariffId}");
        }
        return tariffModel.GetPrice();
    }
}