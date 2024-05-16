using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Commands;

public class UpdateStudyMaterialNameCommand : IRequest 
{
    public string MaterialId { get; set; }
    public string MaterialName { get; set; }

    public UpdateStudyMaterialNameCommand(string materialId, string materialName)
    {
        MaterialId = materialId;
        MaterialName = materialName; 
    }
}