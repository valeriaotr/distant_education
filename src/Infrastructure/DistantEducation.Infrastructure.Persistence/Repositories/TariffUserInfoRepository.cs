using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Models.TariffUserInfo;
using DistantEducation.Infrastructure.Persistence.Contexts;
using DistantEducation.Infrastructure.Persistence.Entity;
using DistantEducation.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace DistantEducation.Infrastructure.Persistence.Repositories;

public class TariffUserInfoRepository : ITariffUserInfoRepository
{
    private readonly ApplicationDbContext _context;
    private const int IdLength = 10;

    public TariffUserInfoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TariffUserInfoModel?> GetParticularTariffInfoById(string userId, string tariffId)
    {
        var infoEntity = await _context.TariffUserInfos.FirstOrDefaultAsync(u => u.TariffId == tariffId && u.UserId == userId);
        return infoEntity != null ? EntityMapper.MapTariffUserInfoEntityToModel(infoEntity) : null;
    }

    public async Task<TariffUserInfoModel?> GetUserInfoById(string userId)
    {
        var infoEntity = await _context.TariffUserInfos.FirstOrDefaultAsync(u => u.UserId == userId);
        return infoEntity != null ? EntityMapper.MapTariffUserInfoEntityToModel(infoEntity) : null;
    }

    public async Task<List<TariffUserInfoModel>> GetAllUserInfo(string userId)
    {
        List<TariffUserInfoModel> infos = await _context.TariffUserInfos
            .Where(t => t.UserId == userId)
            .Select(t => new TariffUserInfoModel(userId, t.Id, t.TariffId, t.StatisticsId, t.PurchaseDate, t.EndDate, t.CourseId))
            .ToListAsync();  
        return infos;
    }

    public async Task<string> AddInfo(TariffUserInfoModel tariffUserInfoModel)
    {
        var newTariffUserInfoEntity = new TariffUserInfoEntity
        {
            Id = Generator.GenerateRandomId(IdLength),
            UserId = tariffUserInfoModel.GetUserId(),
            TariffId = tariffUserInfoModel.GetTariffId(),
            StatisticsId = tariffUserInfoModel.GetStatisticsId(),
            PurchaseDate = tariffUserInfoModel.GetPurchaseDate(),
            EndDate = tariffUserInfoModel.GetEndDate(),
            CourseId = tariffUserInfoModel.GetCourseId()
        };
        await _context.TariffUserInfos.AddAsync(newTariffUserInfoEntity);
        await _context.SaveChangesAsync();
        return newTariffUserInfoEntity.Id;
    }

    public async Task DeleteInfo(string infoId)
    {
        var info = new TariffUserInfoEntity { Id = infoId };
        _context.TariffUserInfos.Attach(info);
        _context.TariffUserInfos.Remove(info);
        await _context.SaveChangesAsync();
    }
}