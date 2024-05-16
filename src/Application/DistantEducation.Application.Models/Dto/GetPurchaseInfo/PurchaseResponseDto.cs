using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.GetPurchaseInfo;

public class PurchaseResponseDto : ResponseBase
{
    public List<PurchaseInfoDto> PurchaseInfo { get; set; }

    public PurchaseResponseDto(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        PurchaseInfo = new List<PurchaseInfoDto>();
    }
}