using MediatR;

namespace DistantEducation.Application.Events.Tariff.Commands;

public class DeleteTariffCommand : IRequest
{
    public string TariffId { get; set; }

    public DeleteTariffCommand(string tariffId)
    {
        TariffId = tariffId;
    }
}