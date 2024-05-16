using DistantEducation.Application.Models.TariffUserInfo;

namespace DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;

public interface ITariffUserInfoRepository
{
    Task<TariffUserInfoModel?> GetParticularTariffInfoById(string userId, string tariffId);
    Task<TariffUserInfoModel?> GetUserInfoById(string userId);
    Task<string> AddInfo(TariffUserInfoModel tariffUserInfoModel);
    Task<List<TariffUserInfoModel>> GetAllUserInfo(string userId);
    Task DeleteInfo(string infoId);
}