using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Commands;

public class DeleteStudyMaterialCommand : IRequest
{
    public string MaterialId { get; set; }

    public DeleteStudyMaterialCommand(string materialId)
    {
        MaterialId = materialId;
    }
}