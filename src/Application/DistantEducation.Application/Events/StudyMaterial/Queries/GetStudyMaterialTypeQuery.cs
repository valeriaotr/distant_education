using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Queries;

public class GetStudyMaterialTypeQuery : IRequest<string>
{
    public string MaterialId { get; set; }

    public GetStudyMaterialTypeQuery(string materialId)
    {
        MaterialId = materialId; 
    }
}