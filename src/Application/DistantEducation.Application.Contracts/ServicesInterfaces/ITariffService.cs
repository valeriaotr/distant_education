using DistantEducation.Application.Models.Tariff;

namespace DistantEducation.Application.Contracts.ServicesInterfaces;

public interface ITariffService
{
    Task<List<TariffModel>> GetAllTariffsAsync();
    Task<TariffModel?> GetTariffAsync(string tariffId);
    Task<string> AddNewTariff(TariffModel tariffModel);
    Task DeleteTariffAsync(string tariffId);
    Task<string?> GetTariffNameAsync(string tariffId);
    Task UpdateTariffNameAsync(string tariffId, string? newName);
    Task<int?> GetTariffPriceAsync(string tariffId);
    Task UpdateTariffPriceAsync(string tariffId, int newPrice);
    Task<int?> GetTariffValidityAsync(string tariffId);
    Task UpdateTariffValidityAsync(string tariffId, int newValidity);
}