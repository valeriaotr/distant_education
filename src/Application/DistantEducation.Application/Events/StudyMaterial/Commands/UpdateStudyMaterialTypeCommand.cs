using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Commands;

public class UpdateStudyMaterialTypeCommand : IRequest
{
    public string MaterialId { get; set; }
    public string MaterialType { get; set; }

    public UpdateStudyMaterialTypeCommand(string materialId, string materialType)
    {
        MaterialId = materialId;
        MaterialType = materialType;
    }
}