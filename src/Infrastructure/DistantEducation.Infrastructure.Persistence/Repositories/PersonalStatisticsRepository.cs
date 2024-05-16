using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Models.PersonalStatistics;
using DistantEducation.Infrastructure.Persistence.Contexts;
using DistantEducation.Infrastructure.Persistence.Entity;
using DistantEducation.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace DistantEducation.Infrastructure.Persistence.Repositories;

public class PersonalStatisticsRepository : IPersonalStatisticsRepository
{
    private readonly ApplicationDbContext _context;

    public PersonalStatisticsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PersonalStatisticsModel?> FindStatisticsById(string statisticsId)
    {
        var statisticsEntity = await _context.Statistics.FirstOrDefaultAsync(s => s.Id == statisticsId);
        return (statisticsEntity != null ? EntityMapper.MapPersonalStatisticsEntityToModel(statisticsEntity) : null)!;
    }

    public async Task AddStatistics(PersonalStatisticsModel statisticsModel)
    {
        var newStatisticsEntity = new PersonalStatisticsEntity
        {
            Id = statisticsModel.GetId(),
            SuccessTasks = statisticsModel.GetSuccessTasks(),
            CommonAmountOfTasks = statisticsModel.GetCommonAmountOfTasks()
        };

        await _context.Statistics.AddAsync(newStatisticsEntity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStatisticsSuccessTasks(PersonalStatisticsModel statisticsModel)
    {
        var tariffEntityToUpdate = ModelMapper.MapPersonalStatisticsModelToEntity(statisticsModel);
        await _context.Statistics.Where(u => u.Id == statisticsModel.GetId())
            .ExecuteUpdateAsync(b => 
                b.SetProperty(u => u.SuccessTasks, tariffEntityToUpdate.SuccessTasks));

        await _context.SaveChangesAsync();
    }

    public async Task DeleteStatistics(string statisticsId)
    {
        var statistics = new PersonalStatisticsEntity { Id = statisticsId };
        _context.Statistics.Attach(statistics);
        _context.Statistics.Remove(statistics);
        await _context.SaveChangesAsync();
    }
}