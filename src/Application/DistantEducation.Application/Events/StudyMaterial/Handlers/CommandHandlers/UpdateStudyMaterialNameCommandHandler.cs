using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.StudyMaterial.Commands;
using DistantEducation.Application.Exceptions.StudyMaterial;
using DistantEducation.Application.Models.StudyMaterial;
using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Handlers.CommandHandlers;

public class UpdateStudyMaterialNameCommandHandler : IRequestHandler<UpdateStudyMaterialNameCommand>
{

    private readonly IStudyMaterialRepository _materialRepository;

    public UpdateStudyMaterialNameCommandHandler(IStudyMaterialRepository studyMaterialRepository)
    {
        _materialRepository = studyMaterialRepository;
    }
    
    public async Task Handle(UpdateStudyMaterialNameCommand request, CancellationToken cancellationToken)
    {
        var materialModel = _materialRepository.FindMaterialById(request.MaterialId).Result;
        if (materialModel == null)
        {
            throw new NullStudyMaterialException($"Material with ID {request.MaterialId} not found");
        }
        var newMaterialModel = StudyMaterialModel.Builder()
            .Id(materialModel.GetId())
            .Name(request.MaterialName)
            .MaterialType(materialModel.GetMaterialType())
            .CourseId(materialModel.GetCourseId())
            .Build();
        await _materialRepository.UpdateMaterialNameAsync(newMaterialModel);
    }
}