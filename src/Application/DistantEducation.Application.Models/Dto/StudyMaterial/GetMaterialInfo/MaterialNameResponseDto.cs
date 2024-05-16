using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.StudyMaterial.GetMaterialInfo;

public class MaterialNameResponseDto : ResponseBase
{
    public string Name { get; set; }

    public MaterialNameResponseDto(string name, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        Name = name;
    }
}