using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.StudyMaterial.Commands;
using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Handlers.CommandHandlers;

public class DeleteStudyMaterialCommandHandler : IRequestHandler<DeleteStudyMaterialCommand>
{
    private readonly IStudyMaterialRepository _materialRepository;

    public DeleteStudyMaterialCommandHandler(IStudyMaterialRepository studyMaterialRepository)
    {
        _materialRepository = studyMaterialRepository;
    }
    
    public async Task Handle(DeleteStudyMaterialCommand request, CancellationToken cancellationToken)
    {
        await _materialRepository.DeleteMaterial(request.MaterialId);
    }
}