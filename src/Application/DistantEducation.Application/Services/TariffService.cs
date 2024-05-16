using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Contracts.ServicesInterfaces;
using DistantEducation.Application.Exceptions.Tariff;
using DistantEducation.Application.Models.Tariff;

namespace DistantEducation.Application.Services;

public class TariffService : ITariffService
{
    private readonly ITariffRepository _tariffRepository;
    
    public TariffService(ITariffRepository tariffRepository)
    {
        _tariffRepository = tariffRepository;
    }
    
    public async Task<List<TariffModel>> GetAllTariffsAsync()
    {
        return await _tariffRepository.FindAllTariffs();
    }

    public async Task<TariffModel?> GetTariffAsync(string tariffId)
    {
        var tariff = await _tariffRepository.FindTariffById(tariffId);
        if (tariff == null)
        {
            throw new NullTariffException($"Tariff with ID {tariffId} not found");
        }

        return tariff;
    }

    public async Task<string> AddNewTariff(TariffModel tariffModel)
    {
        var id = await _tariffRepository.AddTariff(tariffModel);
        return id;
    }

    public async Task DeleteTariffAsync(string tariffId)
    {
        await _tariffRepository.DeleteTariff(tariffId);
    }

    public async Task<string?> GetTariffNameAsync(string tariffId)
    {
        var tariff = await _tariffRepository.FindTariffById(tariffId);
        if (tariff == null)
        {
            throw new NullTariffException($"Tariff with ID {tariffId} not found");
        }
        
        return tariff.GetName();
    }

    public async Task UpdateTariffNameAsync(string tariffId, string? newName)
    {
        var tariff = _tariffRepository.FindTariffById(tariffId).Result;
        if (tariff == null)
        {
            throw new NullTariffException($"Tariff with ID {tariffId} not found");
        }
        
        var newTariff = TariffModel.Builder()
            .Id(tariff.GetId())
            .Name(newName)
            .Price(tariff.GetPrice())
            .Validity(tariff.GetValidity())
            .Build();
        await _tariffRepository.UpdateTariffName(newTariff);
    }

    public async Task<int?> GetTariffPriceAsync(string tariffId)
    {
        var tariff = await _tariffRepository.FindTariffById(tariffId);
        if (tariff == null)
        {
            throw new NullTariffException($"Tariff with ID {tariffId} not found");
        }
        
        return tariff.GetPrice();
    }

    public async Task UpdateTariffPriceAsync(string tariffId, int newPrice)
    {
        var tariff = _tariffRepository.FindTariffById(tariffId).Result;
        if (tariff == null)
        {
            throw new NullTariffException($"Tariff with ID {tariffId} not found");
        }
        
        var newTariff = TariffModel.Builder()
            .Id(tariff.GetId())
            .Name(tariff.GetName())
            .Price(newPrice)
            .Validity(tariff.GetValidity())
            .Build();
        await _tariffRepository.UpdateTariffPrice(newTariff);
    }

    public async Task<int?> GetTariffValidityAsync(string tariffId)
    {
        var tariff = await _tariffRepository.FindTariffById(tariffId);
        if (tariff == null)
        {
            throw new NullTariffException($"Tariff with ID {tariffId} not found");
        }
        
        return tariff.GetValidity();
    }
    
    public async Task UpdateTariffValidityAsync(string tariffId, int newValidity)
    {
        var tariff = _tariffRepository.FindTariffById(tariffId).Result;
        if (tariff == null)
        {
            throw new NullTariffException($"Tariff with ID {tariffId} not found");
        }
        
        var newTariff = TariffModel.Builder()
            .Id(tariff.GetId())
            .Name(tariff.GetName())
            .Price(tariff.GetPrice())
            .Validity(newValidity)
            .Build();
        await _tariffRepository.UpdateTariffValidity(newTariff);
    }
}