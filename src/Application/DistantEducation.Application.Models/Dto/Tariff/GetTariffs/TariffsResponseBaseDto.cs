using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Tariff.GetTariffs;

public class TariffsResponseBaseDto:ResponseBase
{
    public List<TariffDto> Tariffs { get; set; }

    public TariffsResponseBaseDto(HttpStatusCode statusCode, string message):base(statusCode,message)
    {
        Tariffs = new List<TariffDto>();
    }
}