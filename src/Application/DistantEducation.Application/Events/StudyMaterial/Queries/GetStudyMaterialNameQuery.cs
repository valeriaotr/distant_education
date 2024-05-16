using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Queries;

public class GetStudyMaterialNameQuery: IRequest<string>
{
    public string MaterialId { get; set; }

    public GetStudyMaterialNameQuery(string materialId)
    {
        MaterialId = materialId;
    }
}