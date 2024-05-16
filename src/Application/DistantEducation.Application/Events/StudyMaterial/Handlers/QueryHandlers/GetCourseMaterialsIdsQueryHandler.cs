using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.StudyMaterial.Queries;
using DistantEducation.Application.Models.StudyMaterial;
using DistantEducation.Infrastructure.Persistence.Repositories;
using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Handlers.QueryHandlers;

public class GetCourseMaterialsIdsQueryHandler : IRequestHandler<GetCourseMaterialsIdsQuery, List<StudyMaterialModel>>
{
    private readonly IStudyMaterialRepository _materialRepository;

    public GetCourseMaterialsIdsQueryHandler(IStudyMaterialRepository studyMaterialRepository)
    {
        _materialRepository = studyMaterialRepository;
    }
    
    public async Task<List<StudyMaterialModel>> Handle(GetCourseMaterialsIdsQuery request, CancellationToken cancellationToken)
    {
        var models = await _materialRepository.FindAllMaterialsByCourseId(request.CourseId);
        return models;
    }
}