using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Models.StudyMaterial;
using DistantEducation.Infrastructure.Persistence.Contexts;
using DistantEducation.Infrastructure.Persistence.Entity;
using DistantEducation.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace DistantEducation.Infrastructure.Persistence.Repositories;

public class StudyMaterialRepository : IStudyMaterialRepository
{
    private readonly ApplicationDbContext _context;
    private const int IdLength = 10;

    public StudyMaterialRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StudyMaterialModel?> FindMaterialById(string materialId)
    {
        var materialEntity = await _context.Materials.FirstOrDefaultAsync(m => m.Id == materialId);
        return (materialEntity != null ? EntityMapper.MapStudyMaterialEntityToModel(materialEntity) : null)!;
    }

    public async Task<List<StudyMaterialModel>> FindAllMaterialsByCourseId(string courseId)
    {
        List<StudyMaterialModel> materials = await _context.Materials.Select(
                t => new StudyMaterialModel(t.Id, t.Name, t.MaterialType, courseId)
            ) 
            .ToListAsync(); 
        return materials;
    }

    public async Task<string> AddMaterial(StudyMaterialModel materialModel)
    {
        var newMaterialEntity = new StudyMaterialEntity
        {
            Id = Generator.GenerateRandomId(IdLength),
            Name = materialModel.GetName(),
            MaterialType = materialModel.GetMaterialType(),
            CourseId = materialModel.GetCourseId()
            
        };

       _context.Materials.Add(newMaterialEntity);
        await _context.SaveChangesAsync();
        return newMaterialEntity.Id;
    }

    public async Task UpdateMaterialNameAsync(StudyMaterialModel studyMaterialModel)
    {
        
        var materialEntityToUpdate = ModelMapper.MapMaterialModelToEntity(studyMaterialModel);
        await _context.Materials.Where(u => u.Id == studyMaterialModel.GetId())
        .ExecuteUpdateAsync(b => b.SetProperty(u => u.Name, materialEntityToUpdate.Name));

        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateMaterialTypeAsync(StudyMaterialModel studyMaterialModel)
    {
        
        var materialEntityToUpdate = ModelMapper.MapMaterialModelToEntity(studyMaterialModel);
        await _context.Materials.Where(u => u.Id == studyMaterialModel.GetId())
            .ExecuteUpdateAsync(b => b.SetProperty(u => u.MaterialType, materialEntityToUpdate.MaterialType));

        await _context.SaveChangesAsync();
    }

    public async Task DeleteMaterial(string materialId)
    {
        var material = new StudyMaterialEntity { Id = materialId };
        _context.Materials.Attach(material);
        _context.Materials.Remove(material);
        await _context.SaveChangesAsync();
    }
}