using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.StudyMaterial.GetMaterialInfo;

public class MaterialTypeResponseDto : ResponseBase
{
    public string MaterialType { get; set; }

    public MaterialTypeResponseDto(string materialType, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        MaterialType = materialType;
    }
}