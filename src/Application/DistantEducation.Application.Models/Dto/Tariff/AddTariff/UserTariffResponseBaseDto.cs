using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Tariff.AddTariff;

public class UserTariffResponseBaseDto : ResponseBase
{
    public string? InfoId { get; set; }

    public UserTariffResponseBaseDto(string? infoId, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        InfoId = infoId;
    }
}