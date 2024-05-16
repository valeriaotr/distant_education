using DistantEducation.Application.Models.StudyMaterial;
using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Commands;

public class CreateMaterialCommand : IRequest<string>
{
    public StudyMaterialModel StudyMaterialModel { get; set; }

    public CreateMaterialCommand(StudyMaterialModel studyMaterialModel)
    {
        StudyMaterialModel = studyMaterialModel;
    }
}