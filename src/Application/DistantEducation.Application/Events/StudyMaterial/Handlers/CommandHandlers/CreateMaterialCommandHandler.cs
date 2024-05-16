using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.StudyMaterial.Commands;
using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Handlers.CommandHandlers;

public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, string>
{
    private readonly IStudyMaterialRepository _materialRepository;

    public CreateMaterialCommandHandler(IStudyMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    public async Task<string> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        var materialId = await _materialRepository.AddMaterial(request.StudyMaterialModel);
        return materialId;
    }
}