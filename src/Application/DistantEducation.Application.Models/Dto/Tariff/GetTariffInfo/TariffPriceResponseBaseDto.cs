using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Tariff.GetTariffInfo;

public class TariffPriceResponseBaseDto:ResponseBase
{
    public int? Price { get; set; }

    public TariffPriceResponseBaseDto(int? price, HttpStatusCode statusCode,string message):base(statusCode,message)
    {
        Price = price;
    }
}