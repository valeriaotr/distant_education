using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Tariff.Commands;
using DistantEducation.Application.Exceptions.Tariff;
using DistantEducation.Application.Models.Tariff;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Handlers.CommandHandlers;

public class UpdateTariffPriceCommandHandler:IRequestHandler<UpdateTariffPriceCommand>
{
    private readonly ITariffRepository _tariffRepository;

    public UpdateTariffPriceCommandHandler(ITariffRepository tariffRepository)
    {
        _tariffRepository = tariffRepository;
    }
    
    public async Task Handle(UpdateTariffPriceCommand request, CancellationToken cancellationToken)
    {
        var tariffModel = _tariffRepository.FindTariffById(request.TariffId).Result;
        if (tariffModel == null)
        {
            throw new NullTariffException($"Could not find tariff with ID {request.TariffId}");
        }
        var newTariff = TariffModel.Builder()
            .Id(tariffModel.GetId())
            .Name(tariffModel.GetName())
            .Price(request.Price)
            .Validity(tariffModel.GetValidity())
            .Build();
        await _tariffRepository.UpdateTariffPrice(newTariff);
    }
}