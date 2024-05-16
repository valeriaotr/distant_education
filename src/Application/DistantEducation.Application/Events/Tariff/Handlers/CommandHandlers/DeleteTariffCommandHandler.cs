using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.Tariff.Commands;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Handlers.CommandHandlers;

public class DeleteTariffCommandHandler : IRequestHandler<DeleteTariffCommand>
{
    private readonly ITariffRepository _tariffRepository;

    public DeleteTariffCommandHandler(ITariffRepository tariffRepository)
    {
        _tariffRepository = tariffRepository;
    }
    
    public async Task Handle(DeleteTariffCommand request, CancellationToken cancellationToken)
    {
        await _tariffRepository.DeleteTariff(request.TariffId);
    }
}