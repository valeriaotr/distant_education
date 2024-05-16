using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Course.GetCourseMaterials;

public class MaterialInfoDto : ResponseBase
{
    public string MaterialId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string CourseId { get; set; }

    public MaterialInfoDto(string materialId, string name, string type, string courseId, HttpStatusCode statusCode, string message)
        : base(statusCode, message)
    {
        MaterialId = materialId;
        Name = name;
        Type = type;
        CourseId = courseId;
    }
        
}