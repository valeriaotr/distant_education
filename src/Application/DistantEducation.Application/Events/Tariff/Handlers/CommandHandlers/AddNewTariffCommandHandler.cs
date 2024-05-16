using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Tariff.Commands;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Handlers.CommandHandlers;

public class AddNewTariffCommandHandler : IRequestHandler<AddNewTariffCommand, string>
{
    private readonly ITariffRepository _tariffRepository;

    public AddNewTariffCommandHandler(ITariffRepository tariffRepository)
    {
        _tariffRepository = tariffRepository;
    }

    public async Task<string> Handle(AddNewTariffCommand request, CancellationToken cancellationToken)
    {
        await _tariffRepository.AddTariff(request.TariffModel);
        return request.TariffModel.GetId();
    }
}