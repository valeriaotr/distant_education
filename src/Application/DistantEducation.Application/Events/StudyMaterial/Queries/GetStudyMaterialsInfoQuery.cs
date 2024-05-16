using DistantEducation.Application.Models.StudyMaterial;
using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Queries;

public class GetStudyMaterialsInfoQuery : IRequest<StudyMaterialModel>
{
    public string MaterialId { get; set; }

    public GetStudyMaterialsInfoQuery(string materialId)
    {
        MaterialId = materialId;
    }
}