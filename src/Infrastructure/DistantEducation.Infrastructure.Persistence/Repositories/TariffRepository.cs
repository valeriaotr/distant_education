using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Models.Tariff;
using DistantEducation.Infrastructure.Persistence.Contexts;
using DistantEducation.Infrastructure.Persistence.Entity;
using DistantEducation.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace DistantEducation.Infrastructure.Persistence.Repositories;

public class TariffRepository : ITariffRepository
{
    private const int IdLength = 10;
    private readonly ApplicationDbContext _context;

    public TariffRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TariffModel>> FindAllTariffs()
    {
        List<TariffModel> tariffs = await _context.Tariffs.Select(
                t => new TariffModel(t.Id, t.Name, t.Price, t.Validity)
            ) 
            .ToListAsync(); 
        return tariffs;
    }

    public async Task<TariffModel?> FindTariffById(string tariffId)
    {
        var tariffEntity = await _context.Tariffs.FirstOrDefaultAsync(t => t.Id == tariffId);
        return (tariffEntity != null ? EntityMapper.MapTariffEntityToModel(tariffEntity) : null)!;
    }

    public async Task<string> AddTariff(TariffModel tariffModel)
    {
        var newTariffEntity = new TariffEntity
        {
            Id = Generator.GenerateRandomId(IdLength),
            Name = tariffModel.GetName(),
            Price = tariffModel.GetPrice(),
            Validity = tariffModel.GetValidity()
        };

        await _context.Tariffs.AddAsync(newTariffEntity);
        await _context.SaveChangesAsync();
        return newTariffEntity.Id;
    }
    
    public async Task UpdateTariffName(TariffModel tariffModel)
    {
        var tariffEntityToUpdate = ModelMapper.MapTariffModelToEntity(tariffModel);
        await _context.Tariffs.Where(u => u.Id == tariffModel.GetId())
            .ExecuteUpdateAsync(b => 
                b.SetProperty(u => u.Name, tariffEntityToUpdate.Name));

        await _context.SaveChangesAsync();
    }

    public async Task UpdateTariffPrice(TariffModel tariffModel)
    {
        var tariffEntityToUpdate = ModelMapper.MapTariffModelToEntity(tariffModel);
        await _context.Tariffs.Where(u => u.Id == tariffModel.GetId())
            .ExecuteUpdateAsync(b => 
                b.SetProperty(u => u.Price, tariffEntityToUpdate.Price));

        await _context.SaveChangesAsync();
    }

    public async Task UpdateTariffValidity(TariffModel tariffModel)
    {
        var tariffEntityToUpdate = ModelMapper.MapTariffModelToEntity(tariffModel);
        await _context.Tariffs.Where(u => u.Id == tariffModel.GetId())
            .ExecuteUpdateAsync(b => 
                b.SetProperty(u => u.Validity, tariffEntityToUpdate.Validity));

        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteTariff(string tariffId)
    {
        var tariff = new TariffEntity { Id = tariffId };
        _context.Tariffs.Attach(tariff);
        _context.Tariffs.Remove(tariff);
        await _context.SaveChangesAsync();
    }
}