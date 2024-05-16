using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.TariffUserInfo.Commands;
using DistantEducation.Application.Exceptions.TariffUserInfo;
using DistantEducation.Application.Models.TariffUserInfo;
using DistantEducation.Infrastructure.Persistence.Utils;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Handlers.CommandHandlers;

public class AddTariffToUserCommandHandler : IRequestHandler<AddTariffToUserCommand, TariffUserInfoModel>
{
    private readonly ITariffUserInfoRepository _tariffUserInfoRepository;

    public AddTariffToUserCommandHandler(ITariffUserInfoRepository tariffUserInfoRepository)
    {
        _tariffUserInfoRepository = tariffUserInfoRepository;
    }

    public async Task<TariffUserInfoModel> Handle(AddTariffToUserCommand request, CancellationToken cancellationToken)
    {
        var tariffUserInfoModel = TariffUserInfoModel.Builder()
            .UserId(request.UserId)
            .TariffId(request.TariffId)
            .PurchaseDate(DateTime.UtcNow.Date)
            .EndDate(DateTime.UtcNow.AddDays(request.Validity).Date)
            .StatisticsId(Generator.GenerateRandomId(10))
            .CourseId(request.CourseId)
            .Build();
        if (tariffUserInfoModel == null)
        {
            throw new NullTariffUserInfoException($"No info for user {request.UserId} and tariff {request.TariffId}");
        }
        var id = await _tariffUserInfoRepository.AddInfo(tariffUserInfoModel);

        var modelToReturn = TariffUserInfoModel.Builder()
            .TariffUserInfoId(id)
            .CourseId(request.CourseId)
            .StatisticsId(tariffUserInfoModel.GetStatisticsId())
            .Build();

        if (modelToReturn == null)
        {
            throw new NullTariffUserInfoException($"No info for user {request.UserId} and tariff {request.TariffId}");
        }
        return modelToReturn;
    }
}