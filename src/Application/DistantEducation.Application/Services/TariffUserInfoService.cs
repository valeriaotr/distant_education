using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Contracts.ServicesInterfaces;
using DistantEducation.Application.Exceptions.TariffUserInfo;
using DistantEducation.Application.Models.TariffUserInfo;

namespace DistantEducation.Application.Services;

public class TariffUserInfoService : ITariffUserInfoService
{
    private readonly ITariffUserInfoRepository _tariffUserInfoRepository;

    public TariffUserInfoService(ITariffUserInfoRepository tariffUserInfoRepository)
    {
        _tariffUserInfoRepository = tariffUserInfoRepository;
    }
}