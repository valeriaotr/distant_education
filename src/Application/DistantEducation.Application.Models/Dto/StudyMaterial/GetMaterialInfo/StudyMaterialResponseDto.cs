using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.StudyMaterial.GetMaterialInfo;

public class StudyMaterialResponseDto : ResponseBase
{
    public string? StudyMaterialId { get; set; }
    public string? Name { get; set; }
    public string? MaterialType { get; set; }
    public string? CourseId { get; set; }

    public StudyMaterialResponseDto(string? studyMaterialId, string? name, string? materialType, string? courseId,
        HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        StudyMaterialId = studyMaterialId;
        Name = name;
        MaterialType = materialType;
        CourseId = courseId;
    }
}