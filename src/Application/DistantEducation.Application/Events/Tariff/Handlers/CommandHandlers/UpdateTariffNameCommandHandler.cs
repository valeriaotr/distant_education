using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Tariff.Commands;
using DistantEducation.Application.Exceptions.Tariff;
using DistantEducation.Application.Models.Tariff;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Handlers.CommandHandlers;

public class UpdateTariffNameCommandHandler:IRequestHandler<UpdateTariffNameCommand>
{
    private readonly ITariffRepository _tariffRepository;

    public UpdateTariffNameCommandHandler(ITariffRepository tariffRepository)
    {
        _tariffRepository = tariffRepository;
    }
    public async Task Handle(UpdateTariffNameCommand request, CancellationToken cancellationToken)
    {
        var tariffModel = _tariffRepository.FindTariffById(request.TariffId).Result;
        if (tariffModel == null)
        {
            throw new NullTariffException($"Could not find tariff with ID {request.TariffId}");
        }

        var newTariff = TariffModel.Builder()
            .Id(tariffModel.GetId())
            .Name(request.Name)
            .Price(tariffModel.GetPrice())
            .Validity(tariffModel.GetValidity())
            .Build();
        await _tariffRepository.UpdateTariffName(newTariff);
    }
}