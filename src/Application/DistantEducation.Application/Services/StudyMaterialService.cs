using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Contracts.ServicesInterfaces;
using DistantEducation.Application.Exceptions.StudyMaterial;
using DistantEducation.Application.Models.StudyMaterial;

namespace DistantEducation.Application.Services;

public class StudyMaterialService : IStudyMaterialsService
{
    private readonly IStudyMaterialRepository _studyMaterialRepository;

    public StudyMaterialService(IStudyMaterialRepository studyMaterialRepository)
    {
        _studyMaterialRepository = studyMaterialRepository;
    }
    
}