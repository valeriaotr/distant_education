using DistantEducation.Application.Models.StudyMaterial;
using MediatR;

namespace DistantEducation.Application.Events.StudyMaterial.Queries;

public class GetCourseMaterialsIdsQuery : IRequest<List<StudyMaterialModel>>
{
    public string CourseId { get; set; }

    public GetCourseMaterialsIdsQuery(string courseId)
    {
        CourseId = courseId;
    }
}