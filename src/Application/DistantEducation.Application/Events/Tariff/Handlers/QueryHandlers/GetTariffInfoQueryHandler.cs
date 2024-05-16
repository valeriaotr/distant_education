using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Tariff.Queries;
using DistantEducation.Application.Exceptions.Tariff;
using DistantEducation.Application.Models.Tariff;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Handlers.QueryHandlers;

public class GetTariffInfoQueryHandler : IRequestHandler<GetTariffInfoQuery, TariffModel>
{
    private readonly ITariffRepository _tariffRepository;

    public GetTariffInfoQueryHandler(ITariffRepository tariffRepository)
    {
        _tariffRepository = tariffRepository;
    }
    
    public async Task<TariffModel> Handle(GetTariffInfoQuery request, CancellationToken cancellationToken)
    {
        var tariff = await _tariffRepository.FindTariffById(request.TariffId);
        if (tariff == null)
        {
            throw new NullTariffException($"Could not find tariff with ID {request.TariffId}");
        }

        return tariff;
    }
}