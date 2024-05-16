using DistantEducation.Application.Models.StudyMaterial;

namespace DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;

public interface IStudyMaterialRepository
{
    Task<StudyMaterialModel?> FindMaterialById(string materialId);
    Task<List<StudyMaterialModel>> FindAllMaterialsByCourseId(string courseId);
    Task<string> AddMaterial(StudyMaterialModel materialModel);
    Task UpdateMaterialNameAsync(StudyMaterialModel studyMaterialModel);
    
    Task UpdateMaterialTypeAsync(StudyMaterialModel studyMaterialModel);

    Task DeleteMaterial(string materialId);
}