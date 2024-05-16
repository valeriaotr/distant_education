using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Queries;

public class GetStudyMaterialCourseIdQuery : IRequest<string>
{
    public string MaterialId { get; set; }

    public GetStudyMaterialCourseIdQuery(string materialId)
    {
        MaterialId = materialId;
    }
}