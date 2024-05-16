using DistantEducation.Application.Models.Tariff;
using MediatR;

namespace DistantEducation.Application.Events.Tariff.Commands;

public class AddNewTariffCommand : IRequest<string>
{
    public TariffModel TariffModel { get; set; }

    public AddNewTariffCommand(TariffModel tariffModel)
    {
        TariffModel = tariffModel;
    }
}