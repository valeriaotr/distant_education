using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Tariff.GetTariffInfo;

public class TariffValidityResponseBaseDto:ResponseBase
{
    public int? Validity { get; set; }

    public TariffValidityResponseBaseDto(int? validity, HttpStatusCode statusCode, string message):base(statusCode,message)
    {
        Validity = validity;
    }
}