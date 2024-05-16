using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.StudyMaterial.Queries;
using DistantEducation.Application.Exceptions.StudyMaterial;
using DistantEducation.Application.Models.StudyMaterial;
using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Handlers.QueryHandlers;

public class GetStudyMaterialInfoCommandHandler : IRequestHandler<GetStudyMaterialsInfoQuery, StudyMaterialModel>
{
    private readonly IStudyMaterialRepository _materialRepository;

    public GetStudyMaterialInfoCommandHandler(IStudyMaterialRepository studyMaterialRepository)
    {
        _materialRepository = studyMaterialRepository;
    }
    
    public async Task<StudyMaterialModel> Handle(GetStudyMaterialsInfoQuery request, CancellationToken cancellationToken)
    {
        var materialModel = await _materialRepository.FindMaterialById(request.MaterialId);
        if (materialModel == null)
        {
            throw new NullStudyMaterialException($"Material with ID {request.MaterialId} not found");
        }

        return materialModel;
    }
}