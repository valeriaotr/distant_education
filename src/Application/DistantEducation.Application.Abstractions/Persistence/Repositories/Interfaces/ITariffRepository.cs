using DistantEducation.Application.Models.Tariff;

namespace DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;

public interface ITariffRepository
{
    Task<List<TariffModel>> FindAllTariffs();
    Task<TariffModel?> FindTariffById(string tariffId);
    Task<string> AddTariff(TariffModel tariffModel);
    Task UpdateTariffName(TariffModel tariffModel);
    Task UpdateTariffPrice(TariffModel tariffModel);
    Task UpdateTariffValidity(TariffModel tariffModel);
    Task DeleteTariff(string tariffId);
}