using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Tariff.CreateNewTariff;

public class CreateTariffResponseBaseDto:ResponseBase
{
    public string TariffId { get; set; }

    public CreateTariffResponseBaseDto(string tariffId, HttpStatusCode statusCode,string message):base(statusCode,message)
    {
        TariffId = tariffId;
    }
}