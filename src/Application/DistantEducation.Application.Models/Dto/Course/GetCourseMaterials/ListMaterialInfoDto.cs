using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Course.GetCourseMaterials;

public class ListMaterialInfoDto : ResponseBase
{
    public List<MaterialInfoDto> MaterialInfoDtos { get; set; }

    public ListMaterialInfoDto(List<MaterialInfoDto> materialInfoDtos, HttpStatusCode statusCode, string message) : base(
        statusCode, message)
    {
        MaterialInfoDtos = materialInfoDtos;
    }
}