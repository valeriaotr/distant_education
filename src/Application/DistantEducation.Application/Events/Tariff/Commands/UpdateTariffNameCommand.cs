using MediatR;

namespace DistantEducation.Application.Events.Tariff.Commands;

public class UpdateTariffNameCommand : IRequest
{
    public string TariffId { get; set; }
    public string Name { get; set; }

    public UpdateTariffNameCommand(string tariffId, string name)
    {
        TariffId = tariffId;
        Name = name;
    }
}