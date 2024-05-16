using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Tariff.Commands;
using DistantEducation.Application.Exceptions.Tariff;
using DistantEducation.Application.Models.Tariff;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Handlers.CommandHandlers;

public class UpdateTariffValidityCommandHandler:IRequestHandler<UpdateTariffValidityCommand>
{
    private readonly ITariffRepository _tariffRepository;

    public UpdateTariffValidityCommandHandler(ITariffRepository tariffRepository)
    {
        _tariffRepository = tariffRepository;
    }
    
    public async Task Handle(UpdateTariffValidityCommand request, CancellationToken cancellationToken)
    {
        var tariffModel = _tariffRepository.FindTariffById(request.TariffId).Result;
        if (tariffModel == null)
        {
            throw new NullTariffException($"Could not find tariff with ID {request.TariffId}");
        }

        TariffModel model = TariffModel.Builder()
            .Id(tariffModel.GetId())
            .Name(tariffModel.GetName())
            .Price(tariffModel.GetPrice())
            .Validity(request.Validity)
            .Build();

        await _tariffRepository.UpdateTariffValidity(model);
    }
}