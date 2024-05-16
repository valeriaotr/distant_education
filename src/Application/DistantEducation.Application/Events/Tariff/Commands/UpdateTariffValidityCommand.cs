using MediatR;

namespace DistantEducation.Application.Events.Tariff.Commands;

public class UpdateTariffValidityCommand : IRequest
{
    public string TariffId { get; set; }
    public int Validity { get; set; }

    public UpdateTariffValidityCommand(string tariffId, int validity)
    {
        TariffId = tariffId;
        Validity = validity;
    }
}