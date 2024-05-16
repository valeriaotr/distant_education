using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.StudyMaterial.AddNewMaterial;

public class MaterialResponseDto : ResponseBase
{
    public string MaterialId { get; set; }

    public MaterialResponseDto(string materialId, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        MaterialId = materialId;
    }
}