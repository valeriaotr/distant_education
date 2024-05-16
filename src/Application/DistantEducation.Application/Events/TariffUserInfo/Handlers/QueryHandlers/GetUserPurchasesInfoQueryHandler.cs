using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.TariffUserInfo.Queries;
using DistantEducation.Application.Exceptions.TariffUserInfo;
using DistantEducation.Application.Models.TariffUserInfo;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Handlers.QueryHandlers;

public class GetUserPurchasesInfoQueryHandler : IRequestHandler<GetUserPurchasesInfoQuery, List<TariffUserInfoModel>>
{ 
    private readonly ITariffUserInfoRepository _tariffUserInfoRepository;

    public GetUserPurchasesInfoQueryHandler(ITariffUserInfoRepository tariffUserInfoRepository)
    {
        _tariffUserInfoRepository = tariffUserInfoRepository;
    }

    public async Task<List<TariffUserInfoModel>> Handle(GetUserPurchasesInfoQuery request, CancellationToken cancellationToken)
    {
        var infos = await _tariffUserInfoRepository.GetAllUserInfo(request.UserId);
        var purchasesInfos = new List<TariffUserInfoModel>();
        
        foreach (var info in infos)
        {
            var purchaseInfo = TariffUserInfoModel.Builder()
                .TariffId(info.GetTariffId())
                .PurchaseDate(info.GetPurchaseDate())
                .EndDate(info.GetEndDate())
                .Build();
            if (purchaseInfo == null)
            {
                throw new NullTariffUserInfoException($"No purchase info for user with ID {request.UserId}");
            }
            
            purchasesInfos.Add(purchaseInfo);
        }

        return purchasesInfos!;
    }
}