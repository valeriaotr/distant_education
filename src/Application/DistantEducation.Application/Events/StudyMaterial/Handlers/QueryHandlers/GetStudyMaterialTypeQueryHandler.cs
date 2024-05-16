using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.StudyMaterial.Queries;
using DistantEducation.Application.Exceptions.StudyMaterial;
using DistantEducation.Infrastructure.Persistence.Repositories;
using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Handlers.QueryHandlers;

public class GetStudyMaterialTypeQueryHandler : IRequestHandler<GetStudyMaterialTypeQuery, string>
{
    private readonly IStudyMaterialRepository _materialRepository;

    public GetStudyMaterialTypeQueryHandler(IStudyMaterialRepository studyMaterialRepository)
    {
        _materialRepository = studyMaterialRepository;
    }
    
    public async Task<string> Handle(GetStudyMaterialTypeQuery request, CancellationToken cancellationToken)
    {
        var studyMaterial = await _materialRepository.FindMaterialById(request.MaterialId);
        if (studyMaterial == null)
        {
            throw new NullStudyMaterialException($"Material with ID {request.MaterialId} not found");
        }
        return studyMaterial.GetMaterialType();
    }
}